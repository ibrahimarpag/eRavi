using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using eRavi.Formlar.Giris;
using eRavi.Formlar.UstMenu;
using PetekKernel;
using PetekKernel.Fonksiyon;
using RaviDataManager;
using RaviMalzeme;
using RaviMalzeme.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRavi.Formlar
{
    public partial class FrmAnaMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Sirket sirket { get; set; }
        RaviMenu raviMenu { get; set; }
        public IOverlaySplashScreenHandle FLoader { get; set; }
        public void Loader(bool s)
        {
            if (s)
                FLoader = SplashScreenManager.ShowOverlayForm(this);
            else
                SplashScreenManager.CloseOverlayForm(FLoader);
        }
        public FrmAnaMenu(Sirket sirket)
        {
            this.sirket = sirket;
            InitializeComponent();
            this.IconOptions.SetImage("raviikon.png");
            pictureEdit2.Image = pictureEdit2.Image.SetImage("raviikon.png");
            this.Text = "Petek Ravi ® Ticari Tam Entegre Yazılım Sistemi - Versiyon 2024.04.04.1356, Script No: 1341";
            //lblUygulamaAdi.ItemAppearance.Normal.Font = new Font("Tahoma", 10F);
            //lblUygulamaAdi.Caption = "Petek Ravi® Ticari Tam Entegre Yazılım Sistemi - Versiyon 2024.04.04.1356, Script No: 1341";

            pictureEdit1.Image = pictureEdit1.Image.SetImage("xsil.png");
            raviMenu = new RaviMenu(this.sirket, this.solMenu, this.ribbonPageGroup1, this.footerMenu, lookOpenForms);
            raviMenu.LoadUstMenu();
            raviMenu.ClickUstMenu += RaviMenu_ClickUstMenu;
            btnKilitle.ItemClick += (sender, e) =>
            {
                footerMenu.ItemLinks.Clear();
                GirisEkraniAc();
            };
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                if (btnBildirim.ItemAppearance.Normal.BackColor == Color.Orange) 
                {
                    btnBildirim.ItemAppearance.Normal.BackColor = Color.Transparent;
                }
                else
                {
                    //Color.FromArgb(206, 221, 245)
                    btnBildirim.ItemAppearance.Normal.BackColor = Color.Orange;
                }
            };
            timer.Start();
            btnKilitle.ImageOptions.SetSvgImage("kilit", 20, 20);
            btnBildirim.ImageOptions.SetSvgImage("bildirim", 20, 20);
            btnAcikForm.ImageOptions.SetSvgImage("pencereler", 20, 20);
            lookOpenForms.Size = new Size(0, 24);
            lookTema.Size = new Size(0, 24);
            btnAcikForm.ItemClick += (sender, e) => { lookOpenForms.ShowPopup(); };
            btnBildirim.ItemClick += (sender, e) =>
            {
                this.ShowBildirim();
                //DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(this, bildirimGroup, new FlyoutProperties() { Alignment = ContentAlignment.MiddleRight });
                //bildirimGroup.Visible = true;
            };
            #region Tema
            TemaDegistir("Ravi Mavi Tema");
            lookTema.Properties.DataSource = new object[] {
                new { Caption = "Aydınlık Mod" },
                new { Caption = "Karanlık Mod" },
                new { Caption = "Ravi Mavi Tema" },
                new { Caption = "Ravi Turuncu Aydınlık Mod" }
            };
            btnTema.ImageOptions.SetSvgImage("tema", 20, 20);
            btnTema.ItemClick += (sender, e) => { lookTema.ShowPopup(); };
            var col = new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "Caption",
                Caption = "Tema",
                Visible = true,
                VisibleIndex = 0
            };
            lookTema.Properties.PopupView.Columns.Add(col);
            lookTema.Properties.View.RowCellClick += (sender, e) =>
            {
                if (e.Column.FieldName == "Caption")
                {
                    TemaDegistir(e.CellValue.ToString());
                }
            };
            #endregion
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            GirisEkraniAc();
        }
        #region Giriş
        private void GirisEkraniAc()
        {
            var fg = new FrmGiris(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterParent };
            fg.Completed += Fg_Completed;
            //this.Opacity = 0.7;
            fg.ShowDialog(this);
        }
        private async void Fg_Completed(object sender, KullaniciRw e)
        {
            Loader(true);

            Application.DoEvents();
            //sirket = new Sirket(BaglanY.Aktar, P.RaviFirma);
            sirket = (sender as FrmGiris).sirket;
            RaviDesktop rd = new RaviDesktop(this, this.solMenu, this.panelDesktop, this.panelTrash);
            rd.LoadDesktop();
            rd.StardDragDrop();
            rd.ClickDesktopButton += (sender1, e1) =>
            {
                var f2 = new XtraForm() { ShowInTaskbar = false, ShowIcon = false, Text = e1.adi };
                f2.SizeChanged += F2_ResizeEnd;
                f2.Show(this);
            };
            raviMenu.sirket = sirket;
            raviMenu.LoadSolMenu();
            raviMenu.LoadAltMenu(e);
            if (sender is Form f) f.Hide();
            TempTable.LoadStokListe(sirket);
            TempTable.LoadCariListe(sirket);
            await Task.Delay(750);
            Loader(false);
        }
        #endregion

        private object lockObject = new object();

        private void RaviMenu_ClickUstMenu(object sender, RAVIUSTMENU ustMenuTip)
        {
            lock (lockObject)
            {
                Loader(true);
                Application.DoEvents();
                switch (ustMenuTip)
                {
                    case RAVIUSTMENU.NONE:
                        break;
                    case RAVIUSTMENU.SMS:
                        {
                            var fs = new FrmSms(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen };
                            fs.SizeChanged += F2_ResizeEnd;
                            fs.Show(this);
                        }
                        break;
                    case RAVIUSTMENU.MAIL:
                        {
                            var fm = new FrmMail(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen };
                            fm.SizeChanged += F2_ResizeEnd;
                            fm.Show(this);

                        }
                        break;
                    case RAVIUSTMENU.DESTEK:
                        break;
                    case RAVIUSTMENU.TAKVIM:
                        {
                            var fm = new FrmTakvim(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen };
                            fm.SizeChanged += F2_ResizeEnd;
                            fm.Show(this);
                        }
                        break;
                    case RAVIUSTMENU.HESAP:
                        Process.Start("calc");
                        break;
                    case RAVIUSTMENU.MASAUSTU:
                        tabContent.SelectedPageIndex = 0;
                        break;
                    case RAVIUSTMENU.SISTEM:
                        break;
                    case RAVIUSTMENU.RAPOR:
                        {
                            //var fm = new FrmStokListe(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen };
                            //fm.SizeChanged += F2_ResizeEnd;
                            //fm.Show(this);
                        }
                        break;
                    case RAVIUSTMENU.YEDEKLE:
                        break;
                    case RAVIUSTMENU.HAKKINDA:
                        Process.Start("https://www.petekyazilim.com.tr");
                        break;
                    case RAVIUSTMENU.FIRMA:
                        break;
                    case RAVIUSTMENU.KAPAT:
                        //                    DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(this, "Ravi kapatılacak işlemi onaylıyor musunuz?");
                        DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction action = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction() { Caption = "Ravi kapatılacak işlemi onaylıyor musunuz?" };
                        DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "Vazgeç", Result = System.Windows.Forms.DialogResult.No };
                        DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command2 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = "Kapat", Result = System.Windows.Forms.DialogResult.Yes };
                        action.Commands.Add(command1);
                        action.Commands.Add(command2);
                        if (DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(this, action, null, null) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Application.Exit();
                            return;
                        }

                        break;
                    default:
                        break;
                }
                Application.DoEvents();
                Loader(false);
            }
            
        }
        #region Simge Durumuna Küçültülmüş Formlar
        private void F2_ResizeEnd(object sender, EventArgs e)
        {
            if (sender is Form s)
            {
                if (s.WindowState == FormWindowState.Minimized)
                {

                    s.Hide();
                }
            }
            this.Activate();
        }
        #endregion
        #region Açılmış Tüm Formlar
        private Bitmap GetFormSecreenshot(Form s)
        {
            Rectangle bounds = s.Bounds;
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics graph = Graphics.FromImage(bitmap))
            {
                graph.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            return bitmap;
        }
        #endregion
        private void barButtonItem25_ItemClick(object sender, EventArgs e)
        {
            var f2 = new XtraForm() { ShowInTaskbar = false, ShowIcon = false, Text = "Form 1" };
            f2.SizeChanged += F2_ResizeEnd;
            f2.Show(this);

        }
        private void TemaDegistir(string s)
        {
            if (s == "Karanlık Mod")
            {
                this.LookAndFeel.SetSkinStyle(UserLookAndFeel.Default.SkinName, "Tampon Tema");
                solMenu.ViewType = AccordionControlViewType.Standard;
            }
            else if (s == "Aydınlık Mod")
            {
                this.LookAndFeel.SetSkinStyle(UserLookAndFeel.Default.SkinName, "Tampon Tema");
                solMenu.ViewType = AccordionControlViewType.Standard;
            }
            else if (s == "Ravi Mavi Tema")
            {
                this.LookAndFeel.SetSkinStyle(UserLookAndFeel.Default.SkinName, "Ravi Mavi Tema");
                solMenu.ViewType = AccordionControlViewType.HamburgerMenu;
            }
            else
            {
                this.LookAndFeel.SetSkinStyle(UserLookAndFeel.Default.SkinName, "Tampon Tema");
                solMenu.ViewType = AccordionControlViewType.HamburgerMenu;
            }
            Application.DoEvents();
            this.LookAndFeel.SetSkinStyle(UserLookAndFeel.Default.SkinName, s);
        }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rbMenu_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
