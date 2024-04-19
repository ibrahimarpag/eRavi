//using DevExpress.XtraEditors.ButtonsPanelControl;
//using DevExpress.XtraEditors;
//using DevExpress.XtraGrid.Columns;
//using DevExpress.XtraSplashScreen;
//using Newtonsoft.Json;
//using PetekKernel.Fonksiyon;
//using PetekKernel;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

//namespace RaviMalzeme.Manager
//{
//    public static class RaviBildirim1
//    {
//        public static DevExpress.XtraEditors.GroupControl bildirimGroup;
//        public static DevExpress.XtraGrid.GridControl gridControl1;
//        public static DevExpress.XtraGrid.Views.Tile.TileView tileView1;
//        public static TileViewColumn colDate;
//        public static XtraForm FrmBildirim;
//        public static void Load()
//        {
//            RaviBildirim1.bildirimGroup = new DevExpress.XtraEditors.GroupControl();
//            RaviBildirim1.gridControl1 = new DevExpress.XtraGrid.GridControl();
//            RaviBildirim1.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();

//            RaviBildirim1.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
//            RaviBildirim1.gridControl1.Location = new System.Drawing.Point(0, 0);
//            RaviBildirim1.gridControl1.MainView = RaviBildirim1.tileView1;
//            RaviBildirim1.gridControl1.Name = "gridControl1";
//            RaviBildirim1.gridControl1.Size = new System.Drawing.Size(513, 432);
//            RaviBildirim1.gridControl1.TabIndex = 0;
//            RaviBildirim1.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
//            RaviBildirim1.tileView1});

//            RaviBildirim1.tileView1.FocusBorderColor = System.Drawing.Color.Transparent;
//            RaviBildirim1.tileView1.GridControl = RaviBildirim1.gridControl1;
//            RaviBildirim1.tileView1.OptionsBehavior.AllowSmoothScrolling = true;
//            RaviBildirim1.tileView1.OptionsTiles.AllowPressAnimation = false;
//            RaviBildirim1.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(30, 10, 0, 10);
//            RaviBildirim1.tileView1.OptionsTiles.HighlightFocusedTileStyle = DevExpress.XtraGrid.Views.Tile.HighlightFocusedTileStyle.None;
//            RaviBildirim1.tileView1.OptionsTiles.IndentBetweenGroups = 0;
//            RaviBildirim1.tileView1.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(0, 8, 12, 8);
//            RaviBildirim1.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(560, 84);
//            RaviBildirim1.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
//            RaviBildirim1.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
//            RaviBildirim1.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
//            RaviBildirim1.tileView1.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;

//            RaviBildirim1.tileView1.TileHtmlTemplate.Styles = RaviResimKontrol.GetBildirimStyle();
//            RaviBildirim1.tileView1.TileHtmlTemplate.Tag = "Tile Template";
//            RaviBildirim1.tileView1.TileHtmlTemplate.Template = RaviResimKontrol.GetBildirimHtml();

//            RaviBildirim1.bildirimGroup.Controls.Add(RaviBildirim1.gridControl1);
//            RaviBildirim1.bildirimGroup.Dock = System.Windows.Forms.DockStyle.Right;
//            RaviBildirim1.bildirimGroup.Location = new System.Drawing.Point(727, 31);
//            RaviBildirim1.bildirimGroup.Name = "bildirimGroup";
//            RaviBildirim1.bildirimGroup.Size = new System.Drawing.Size(295, 736);
//            RaviBildirim1.bildirimGroup.Text = "HABERLER";
//            var kb = new GroupBoxButton() { Caption = "", Tag = "kapat" };
//            kb.ImageOptions.SetSvgImage("xkapat", 16, 16);
//            var ky = new GroupBoxButton() { Caption = "", Tag = "yenile" };
//            ky.ImageOptions.SetSvgImage("yenile", 16, 16);
//            RaviBildirim1.bildirimGroup.CustomHeaderButtons.Add(ky);
//            RaviBildirim1.bildirimGroup.CustomHeaderButtons.Add(kb);
//            RaviBildirim1.bildirimGroup.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
//            RaviBildirim1.tileView1.CustomItemTemplate += (s, e) =>
//            {
//                dynamic rw = RaviBildirim1.tileView1.GetRow(e.RowHandle);
//                string html = "";
//                html += @"<div class=""content"">
//		<div class=""mail-content"" style=""height: 300px;"">";
//                foreach (var item in rw.detay)
//                {
//                    html += @"
//            <div class=""from"" id=""from"">" + item.kisaBaslik + @"</div>
//            <div class=""subject"" id=""subject"">" + item.kisaAciklama + @"</div>";

//                }
//                html += @"
//			<div class=""tarih"">${eklemeTarihi}</div>
//		</div></div>";
//                e.HtmlTemplate.Template = html;
//            };


//        }
//        public static async void ShowBildirim(this Form f)
//        {
//            if (FrmBildirim == null)
//            {
//                Load();
//                FrmBildirim = new XtraForm();
//                FrmBildirim.Name = "FrmBildirim";
//                FrmBildirim.FormBorderStyle = FormBorderStyle.None;
//                bildirimGroup.Dock = DockStyle.Fill;
//                FrmBildirim.Controls.Add(bildirimGroup);
//                FrmBildirim.Height = f.Height;
//                FrmBildirim.KeyPreview = true;
//                FrmBildirim.KeyUp += (sender, e) => { if (e.KeyCode == Keys.Escape) FrmBildirim.Hide(); f.Focus(); };
//                RaviBildirim1.bildirimGroup.CustomButtonClick += async (sender, e) =>
//                {
//                    if (e.Button is GroupBoxButton b)
//                    {
//                        if (b.Tag.StrX() == "kapat") { FrmBildirim.Hide(); f.Focus(); }
//                        else if (b.Tag.StrX() == "yenile") await RefreshData();
//                    }
//                };
//                FrmBildirim.ShowInTaskbar = false;
//                FrmBildirim.Show(f);
//                f.LocationChanged += (sender, e) => { SetLocation(f); };
//                f.SizeChanged += (sender, e) => { FrmBildirim.Height = f.Height; };
//                SetLocation(f);
//                await RefreshData();
//            }
//            else
//            {
//                FrmBildirim.Show(f);
//            }
//        }
//        private static async Task RefreshData()
//        {
//            Loader(true);
//            gridControl1.DataSource = (await GetBildirimListe()).detay;
//            Loader(false);
//        }
//        public static async Task<dynamic> GetBildirimListe()
//        {
//            dynamic Data = null;
//            try
//            {
//                HttpClient client = new HttpClient();
//                client.DefaultRequestHeaders.Add("Accepty", "Application/json");
//                var response = await client.GetAsync("https://ravi-versiyon.petekyazilim.com/versiyon/get/2024.03.17.1251");
//                if (response.StatusCode == System.Net.HttpStatusCode.OK)
//                {
//                    var result = await response.Content.ReadAsStringAsync();
//                    Data = JsonConvert.DeserializeObject<dynamic>(result);
                    
//                    foreach (var item in Data.detay)
//                    {
//                        foreach (var detay in item.detay)
//                        {
//                            item.HtmlContent += $"<div class='detail-item baslik'>{detay.baslik}</div><br/><div class='detail-item aciklama'>{detay.aciklama}</div>";
//                        }
//                    }
//                    RaviBildirim1.tileView1.TileHtmlTemplate.Tag = Data;
//                }
//                else
//                {
//                    fn.LogYaz("(Bildirim.Hata):" + DateTime.Now.ToString() + "; Durum. GetBildirimListe" + $"; Konum.Base Manager:{(await response.Content.ReadAsStringAsync())}", "Bildirim");
//                }
//            }
//            catch (Exception ex)
//            {
//                fn.LogYaz("(Bildirim.Hata):" + DateTime.Now.ToString() + "; Durum. GetBildirimListe" + $"; Konum.Ravi Bildirim:{ex.Message}", "Bildirim");
//            }
//            return Data;
//        }
//        public static IOverlaySplashScreenHandle FLoader { get; set; }
//        private static void Loader(bool s)
//        {
//            if (s)
//                FLoader = SplashScreenManager.ShowOverlayForm(FrmBildirim);
//            else
//                SplashScreenManager.CloseOverlayForm(FLoader);
//        }
//        private static void SetLocation(Form f)
//        {
//            if (f.WindowState == FormWindowState.Maximized)
//            {
//                FrmBildirim.Height = f.Height - 8;
//                FrmBildirim.Location = new System.Drawing.Point(f.Location.X + f.Width - bildirimGroup.Width - 5, f.Location.Y + 8);
//            }
//            else
//            {
//                FrmBildirim.Location = new System.Drawing.Point(f.Location.X + f.Width - bildirimGroup.Width, f.Location.Y);
//            }
//        }
//    }
//}
