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

namespace RaviMalzeme.Manager
{
    public static class RaviBildirim
    {
        public static DevExpress.XtraEditors.GroupControl bildirimGroup;
        public static DevExpress.XtraGrid.GridControl gridControl1;
        public static DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        public static TileViewColumn colDate;
        public static XtraForm FrmBildirim;
        public static void Load()
        {
            RaviBildirim.bildirimGroup = new DevExpress.XtraEditors.GroupControl();
            RaviBildirim.gridControl1 = new DevExpress.XtraGrid.GridControl();
            RaviBildirim.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();

            RaviBildirim.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            RaviBildirim.gridControl1.Location = new System.Drawing.Point(0, 0);
            RaviBildirim.gridControl1.MainView = RaviBildirim.tileView1;
            RaviBildirim.gridControl1.Name = "gridControl1";
            RaviBildirim.gridControl1.Size = new System.Drawing.Size(513, 432);
            RaviBildirim.gridControl1.TabIndex = 0;
            RaviBildirim.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            RaviBildirim.tileView1});

            RaviBildirim.tileView1.FocusBorderColor = System.Drawing.Color.Transparent;
            RaviBildirim.tileView1.GridControl = RaviBildirim.gridControl1;
            RaviBildirim.tileView1.OptionsBehavior.AllowSmoothScrolling = true;
            RaviBildirim.tileView1.OptionsTiles.AllowPressAnimation = false;
            RaviBildirim.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(30, 10, 0, 10);
            RaviBildirim.tileView1.OptionsTiles.HighlightFocusedTileStyle = DevExpress.XtraGrid.Views.Tile.HighlightFocusedTileStyle.None;
            RaviBildirim.tileView1.OptionsTiles.IndentBetweenGroups = 0;
            RaviBildirim.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0, 8, 12, 8);
            RaviBildirim.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(560, 84);
            RaviBildirim.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            RaviBildirim.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            RaviBildirim.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            RaviBildirim.tileView1.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;

            RaviBildirim.tileView1.TileHtmlTemplate.Styles = RaviResimKontrol.GetBildirimStyle();
            RaviBildirim.tileView1.TileHtmlTemplate.Tag = "Tile Template";
            RaviBildirim.tileView1.TileHtmlTemplate.Template = RaviResimKontrol.GetBildirimHtml();

            RaviBildirim.bildirimGroup.Controls.Add(RaviBildirim.gridControl1);
            RaviBildirim.bildirimGroup.Dock = System.Windows.Forms.DockStyle.Right;
            RaviBildirim.bildirimGroup.Location = new System.Drawing.Point(727, 31);
            RaviBildirim.bildirimGroup.Name = "bildirimGroup";
            RaviBildirim.bildirimGroup.Size = new System.Drawing.Size(295, 736);
            RaviBildirim.bildirimGroup.Text = "HABERLER";
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
            if (FrmBildirim == null)
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
            else
            {
                FrmBildirim.Show(f);
            }
        }
        private static async Task RefreshData()
        {
            Loader(true);
            gridControl1.DataSource = await GetBildirimListe();
            Loader(false);
        }
        public static async Task<List<object>> GetBildirimListe()
        {
            var Data = new List<object>();
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accepty", "Application/json");
                var response = await client.GetAsync("https://ravi_lapi.petekyazilim.com/ravi_lapi/ravi/bildirim-v1?kurulumno");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var cevap = JsonConvert.DeserializeObject<RaviResult>(result);
                    if (cevap.Success)
                        Data = JsonConvert.DeserializeObject<List<object>>(cevap.Data.ToString());
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
