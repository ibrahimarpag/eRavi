using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using Newtonsoft.Json;
using PetekKernel.Fonksiyon;
using PetekKernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DevExpress.Utils.Layout;
using DevExpress.LookAndFeel;

namespace RaviMalzeme.Manager
{
    public static class RaviBildirim
    {
        public static DevExpress.XtraEditors.GroupControl bildirimGroup;
        static RaviBildirimRow stackPanel { get; set; }
        //public static DevExpress.XtraGrid.GridControl gridControl1;
        //public static DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        //public static TileViewColumn colDate;
        public static XtraForm FrmBildirim;
        public static void Load()
        {
            RaviBildirim.bildirimGroup = new DevExpress.XtraEditors.GroupControl();
            RaviBildirim.stackPanel = new RaviBildirimRow();


            RaviBildirim.bildirimGroup.Controls.Add(RaviBildirim.stackPanel);
            RaviBildirim.bildirimGroup.Dock = System.Windows.Forms.DockStyle.Right;
            RaviBildirim.bildirimGroup.Location = new System.Drawing.Point(727, 31);
            RaviBildirim.bildirimGroup.Name = "bildirimGroup";
            RaviBildirim.bildirimGroup.Size = new System.Drawing.Size(295, 736);
            RaviBildirim.bildirimGroup.Text = "Versiyon Notları";
            var kb = new GroupBoxButton() { Caption = "", Tag = "kapat" };
            kb.ImageOptions.SetSvgImage("xkapat", 16, 16);
            var ky = new GroupBoxButton() { Caption = "", Tag = "yenile" };
            ky.ImageOptions.SetSvgImage("yenile", 16, 16);
            RaviBildirim.bildirimGroup.CustomHeaderButtons.Add(ky);
            RaviBildirim.bildirimGroup.CustomHeaderButtons.Add(kb);
            RaviBildirim.bildirimGroup.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
        }
        public static async void ShowBildirim(this Form f)
        {
            if (true)
            {
                Load();
                FrmBildirim = new XtraForm();
                FrmBildirim.Name = "FrmBildirim";
                FrmBildirim.FormBorderStyle = FormBorderStyle.None;
                bildirimGroup.Dock = DockStyle.Fill;
                FrmBildirim.Controls.Add(bildirimGroup);
                FrmBildirim.Height = f.Height;
                FrmBildirim.KeyPreview = true;
                FrmBildirim.KeyUp += (sender, e) => { if (e.KeyCode == Keys.Escape) FrmBildirim.Hide(); f.Focus(); };
                RaviBildirim.bildirimGroup.CustomButtonClick += async (sender, e) =>
                {
                    if (e.Button is GroupBoxButton b)
                    {
                        if (b.Tag.StrX() == "kapat") { FrmBildirim.Hide(); f.Focus(); }
                        else if (b.Tag.StrX() == "yenile") await RefreshData();
                    }
                };
                FrmBildirim.ShowInTaskbar = false;
                FrmBildirim.Show(f);
                f.LocationChanged += (sender, e) => { SetLocation(f); };
                f.SizeChanged += (sender, e) => { FrmBildirim.Height = f.Height; };
                SetLocation(f);
                await RefreshData();
            }
            //else
            //{
            //    FrmBildirim.Show(f);
            //}
        }
        private static async Task RefreshData()
        {
            Loader(true);
            RaviBildirim.stackPanel.Controls.Clear();
            Application.DoEvents();
            RaviBildirim.stackPanel.LoadData(await GetBildirimListe());
            Loader(false);
        }
        public static async Task<List<dynamic>> GetBildirimListe()
        {
            var Data = new List<dynamic>();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accepty", "Application/json");
                var response = await client.GetAsync("https://ravi-versiyon.petekyazilim.com/versiyon/get/2024.03.17.1251");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var Veri = JsonConvert.DeserializeObject<dynamic>(result);
                    foreach (var item in Veri.detay)
                    {
                        var rw = new { item.aciklama, detay = new List<dynamic>() };
                        foreach (var detay in item.detay) rw.detay.Add(new { detay.baslik, detay.aciklama });
                        Data.Add(rw);
                    }
                }
                else
                {
                    fn.LogYaz("(Bildirim.Hata):" + DateTime.Now.ToString() + "; Durum. GetBildirimListe" + $"; Konum.Base Manager:{(await response.Content.ReadAsStringAsync())}", "Bildirim");
                }
            }
            catch (Exception ex)
            {
                fn.LogYaz("(Bildirim.Hata):" + DateTime.Now.ToString() + "; Durum. GetBildirimListe" + $"; Konum.Ravi Bildirim:{ex.Message}", "Bildirim");
            }
            return Data;
        }
        public static IOverlaySplashScreenHandle FLoader { get; set; }
        private static void Loader(bool s)
        {
            if (s)
                FLoader = SplashScreenManager.ShowOverlayForm(FrmBildirim);
            else
                SplashScreenManager.CloseOverlayForm(FLoader);
        }
        private static void SetLocation(Form f)
        {
            if (f.WindowState == FormWindowState.Maximized)
            {
                FrmBildirim.Height = f.Height - 8;
                FrmBildirim.Location = new System.Drawing.Point(f.Location.X + f.Width - bildirimGroup.Width - 5, f.Location.Y + 8);
            }
            else
            {
                FrmBildirim.Location = new System.Drawing.Point(f.Location.X + f.Width - bildirimGroup.Width, f.Location.Y);
            }
        }
    }
}
