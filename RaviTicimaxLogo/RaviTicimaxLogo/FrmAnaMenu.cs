using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using eRavi.Formlar.Giris;
using PetekKernel;
using RaviMalzeme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviTicimaxLogo
{
    public partial class FrmAnaMenu : XtraForm
    {
        public Sirket sirket { get; set; }
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
            imageLogo.Image=imageLogo.Image.SetImage("petekyazilim.png");
            if (ProjectSettings.Yazilim==EYazilim.beyazel)
            {
                btnDokulenUrunKontrol.Text = "6. Madde";
            }
            btnMaximized.Click += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
                else this.WindowState = FormWindowState.Maximized;
            };
            btnMinimized.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnKapat.Click += (s, e) => Application.Exit();
            btnMenuKapat.Click += (s, e) => Application.Exit();
            btnDokulenUrunKontrol.Click += (s, e) =>
            {
                if (ProjectSettings.Yazilim == EYazilim.beyazel)
                {
                    var frm = new FrmSiparisListe();
                    frm.ShowDialog(this);
                }
                else
                {
                    var frm = new FrmRaviSiparisListe();
                    frm.ShowDialog(this);
                }
            };
        }
        private void CenterPanel()
        {
            panelCenter.Left = (this.ClientSize.Width - panelCenter.Width) / 2;
            panelCenter.Top = (this.ClientSize.Height - panelCenter.Height) / 2;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CenterPanel();
            GirisEkraniAc();
            this.ClientSizeChanged += (s, ee) => CenterPanel();
        }
        #region Giriş
        private void GirisEkraniAc()
        {
            var fg = new FrmGiris(this.sirket) { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterScreen };
            fg.Completed += Fg_Completed;
            //this.Opacity = 0.7;
            fg.ShowDialog(this);
        }
        private async void Fg_Completed(object sender, KullaniciRw e)
        {
            Loader(true);

            Application.DoEvents();
            sirket = (sender as FrmGiris).sirket;
            if (sender is Form f) f.Hide();
            await Task.Delay(750);
            Loader(false);
        }
        #endregion
    }
}
