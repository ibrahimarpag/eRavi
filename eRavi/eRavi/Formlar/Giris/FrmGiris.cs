using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using PetekKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaviDataManager.Manager;
using RaviMalzeme;
using RaviMalzeme.Manager;

namespace eRavi.Formlar.Giris
{
    public partial class FrmGiris : XtraForm
    {
        public IOverlaySplashScreenHandle FLoader { get; set; }
        public void Loader(bool s)
        {
            if (s)
                FLoader = SplashScreenManager.ShowOverlayForm(this);
            else
                SplashScreenManager.CloseOverlayForm(FLoader);
        }
        public event EventHandler<KullaniciRw> Completed = delegate { };
        public Sirket sirket { get; set; }
        public FrmGiris(Sirket sirket)
        {
            this.sirket = sirket;
            InitializeComponent();

            this.Text = "Ravi Giriş";
            txtKullanici.Text = this.sirket.IniReadValue("login", "Kullanici");
            txtFirma.Text = this.sirket.IniReadValue("login", "Firma");

            SetControlDefault();
            LoadEvent();
        }
        private void LoadEvent()
        {
            imageKullanici.Click += (sender, e) => { txtKullanici.Focus(); SendKeys.Send("{F10}"); };
            imageFirma.Click += (sender, e) => { txtFirma.Focus(); SendKeys.Send("{F10}"); };
            imageSifre.Click += (sender, e) => { txtSifre.Focus(); };
            btnGiris.Click += BtnGiris_Click;
            btnVazgec.Click += (sender, e) => { Application.Exit(); };
            txtSifre.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(txtSifre.Text))
                {
                    txtSifre.Properties.PasswordChar = '\0';
                    txtSifre.Text = null;
                }
                else txtSifre.Properties.PasswordChar = '●';
            };
            txtFirma.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.F10)
                {
                    FrmFirmaVeyaKullanici f = new FrmFirmaVeyaKullanici(this.sirket, "firma");
                    f.SelectedRow += (s, e1) =>
                    {
                        f.Close();
                        txtFirma.Text = e1;
                    };
                    f.ShowDialog();
                }
            };
            txtSifre.KeyUp += (sender, e) => { if (e.KeyCode == Keys.Enter) BtnGiris_Click(sender, e); };
            txtKullanici.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.F10)
                {
                    FrmFirmaVeyaKullanici f = new FrmFirmaVeyaKullanici(this.sirket, "kullanici", txtFirma.Text);
                    f.SelectedRow += (s, e1) =>
                    {
                        f.Close();
                        txtKullanici.Text = e1;
                    };
                    f.ShowDialog();
                }
            };
            txtKullanici.TextChanged += Txt_TextChanged;
            txtFirma.TextChanged += Txt_TextChanged;
            this.FormClosing += (sender, e) => { if (e.CloseReason == CloseReason.UserClosing) Application.Exit(); };

            btnDil.Click += (sender, e) =>
            {
                FrmFirmaVeyaKullanici f = new FrmFirmaVeyaKullanici(this.sirket, "dil");
                f.SelectedRow += (s, e1) =>
                {
                    f.Close();
                    btnDil.ImageOptions.SetImageFile($"{e1}.png");
                };
                f.ShowDialog();
            };
        }
        private void SetControlDefault()
        {
            this.MaximizeBox = false;

            btnDestek.ImageOptions.Location = ImageLocation.MiddleCenter;
            btnKlavye.ImageOptions.Location = ImageLocation.MiddleCenter;
            btnVazgec.ImageOptions.Location = ImageLocation.MiddleCenter;
            btnDil.ImageOptions.Location = ImageLocation.MiddleCenter;

            btnDestek.AllowFocus = false;
            btnKlavye.AllowFocus = false;
            btnVazgec.AllowFocus = false;
            btnDil.AllowFocus = false;

            btnDil.ImageOptions.SetSvgImage("turkiye", 48, 48);
            btnDestek.ImageOptions.SetSvgImage("destek", 48, 48);
            btnKlavye.ImageOptions.SetSvgImage("klavye", 48, 48);
            btnVazgec.ImageOptions.SetSvgImage("xkapat", 48, 48);
            this.IconOptions.SetImage("logo.png");
            imageKullanici.SetSvgImage("kullanici", 20, 20);
            imageSifre.SetSvgImage("kilit", 24, 24);
            imageFirma.SetSvgImage("firma", 20, 20);

            imageKullanici.Properties.AllowFocused = false;
            imageSifre.Properties.AllowFocused = false;
            imageFirma.Properties.AllowFocused = false;
            btnGiris.AllowFocus = false;

            btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDestek.Cursor = System.Windows.Forms.Cursors.Hand;
            btnKlavye.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVazgec.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDil.Cursor = System.Windows.Forms.Cursors.Hand;
            lblPetekUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            imageKullanici.Cursor = System.Windows.Forms.Cursors.Hand;
            imageFirma.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            Loader(true);
            Application.DoEvents();
            var result = this.sirket.LoginKontrol(txtFirma.Text, txtKullanici.Text, txtSifre.Text);

            if (result.Devam)
            {
                KullaniciRw kullaniciRw = new KullaniciTb(this.sirket).Getir(txtKullanici.Text, txtSifre.Text);
                P.RaviFirma = txtFirma.Text;
                this.sirket = new Sirket(BaglanY.Aktar, txtFirma.Text);
                this.sirket.Baglan();
                new P(this.sirket).Getir(kullaniciRw.Kodu);
                Completed.Invoke(this, kullaniciRw);
                this.sirket.IniWriteValue("login", "Kullanici", txtKullanici.Text);
                this.sirket.IniWriteValue("login", "Firma", txtFirma.Text);
            }
            else
            {
                this.Owner.ShowUyari("Uyarı", result.Mesaj, "Tamam");
            }
            Loader(false);
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextEdit t) if (string.IsNullOrEmpty(t.Text)) t.Text = null;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtSifre.Focus();
        }
    }
}
