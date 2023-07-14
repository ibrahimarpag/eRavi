using DevExpress.XtraEditors;
using RaviDataManager;
using RaviMalzeme.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaviMalzeme;
using eRavi.Formlar.Listeler;
using PetekKernel;
using RaviMalzeme.BaseForms;

namespace eRavi.Formlar.UstMenu
{
    public partial class FrmSms : BasePropertyForm
    {
        public FrmSms(Sirket sirket) : base(sirket)
        {
            InitializeComponent();
            base.ustMenu = new TopStackPanel("Genel Kullanıcı, Hareket Ekstresi.frx", FORMTIP.SMS);
            this.Controls.Add(ustMenu);
            this.Height += 65;
            this.SetFormIcon(FORMTIP.SMS, "SMS");
            this.Resize += FrmMail_ResizeEnd;
            txtCariIlk.ReadOnly = true;
            txtCariSon.ReadOnly = true;
            base.ustMenu.ClickButton += (sender, e) =>
            {
                if (e == USTMENUBUTTONTIP.KAPAT) this.Close();
            };
            txtCariIlk.ListeClick += (sender, e) =>
            {
                FrmCariListe frm = new FrmCariListe(this.sirket) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, cari) =>
                {
                    txtCariIlk.Text = cari.cari_kodu;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtCariSon.ListeClick += (sender, e) =>
            {
                FrmCariListe frm = new FrmCariListe(this.sirket) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, cari) =>
                {
                    txtCariSon.Text = cari.cari_kodu;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtTanim1.ListeClick += (sender, e) =>
            {
                FrmTanimListe frm = new FrmTanimListe(this.sirket, "Cari Grup 1", FORMTIP.TANIM, GRIDFTIP.TANIM, GRIDEKEY.LISTE, CariTanim.GrupKodu) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtTanim1.Text = row.aciklama;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtTanim2.ListeClick += (sender, e) =>
            {
                FrmTanimListe frm = new FrmTanimListe(this.sirket, "Cari Grup 2", FORMTIP.TANIM, GRIDFTIP.TANIM, GRIDEKEY.LISTE, CariTanim.OzelKodu) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtTanim2.Text = row.aciklama;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtTanim3.ListeClick += (sender, e) =>
            {
                FrmTanimListe frm = new FrmTanimListe(this.sirket, "Cari Grup 3", FORMTIP.TANIM, GRIDFTIP.TANIM, GRIDEKEY.LISTE, CariTanim.RaporGrup) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtTanim3.Text = row.aciklama;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtTanim4.ListeClick += (sender, e) =>
            {
                FrmTanimListe frm = new FrmTanimListe(this.sirket, "Cari Grup 4", FORMTIP.TANIM, GRIDFTIP.TANIM, GRIDEKEY.LISTE, CariTanim.AnaGrup) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtTanim4.Text = row.aciklama;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtTanim5.ListeClick += (sender, e) =>
            {
                FrmTanimListe frm = new FrmTanimListe(this.sirket, "Cari Grup 5", FORMTIP.TANIM, GRIDFTIP.TANIM, GRIDEKEY.LISTE, CariTanim.TaliGrup) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtTanim5.Text = row.aciklama;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
            txtSatici.ListeClick += (sender, e) =>
            {
                FrmSaticiListe frm = new FrmSaticiListe(this.sirket, "Satıcı Liste", FORMTIP.TANIM, GRIDFTIP.SATICI, GRIDEKEY.LISTE) { StartPosition = FormStartPosition.CenterParent };
                frm.SelectRow += (s, row) =>
                {
                    txtSatici.Text = row.satici_kodu;
                    frm.Close();
                };
                frm.ShowDialog(this);
            };
        }
        public void Center()
        {
            panelCenter.Location = new Point(xtraTabPage1.Width / 2 - panelCenter.Width / 2, xtraTabPage1.Height / 2 - panelCenter.Height / 2);
        }
        private void FrmMail_ResizeEnd(object sender, EventArgs e)
        {
            Center();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Application.DoEvents();
            Center();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raviDateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void raviDateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
