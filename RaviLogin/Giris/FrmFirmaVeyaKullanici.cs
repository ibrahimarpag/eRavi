using DevExpress.XtraEditors;
using PetekKernel;
using RaviDataManager;
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
using RaviDataManager.Manager;
using RaviDataManager.Models;

namespace eRavi.Formlar.Giris
{
    public partial class FrmFirmaVeyaKullanici : XtraForm
    {
        public event EventHandler<string> SelectedRow = delegate { };
        private Sirket sirket { get; set; }
        private string liste { get; set; }
        private string firma { get; set; }
        public FrmFirmaVeyaKullanici(Sirket sirket, string liste, string firma = "")
        {
            this.sirket = sirket;
            this.liste = liste;
            this.firma = firma;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.KeyUp += (sender, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ManagerSistem manager = new ManagerSistem();
            if (liste == "firma")
            {
                this.SetFormIcon(FORMTIP.FIRMA, "FİRMA SEÇİM EKRANI");
                var FirmaListe = manager.GetFirmaListe();
                listBoxControl1.DataSource = FirmaListe.ToList();
                listBoxControl1.DisplayMember = "firma_adi";
                listBoxControl1.ValueMember = "firmano";
            }
            else if (liste == "kullanici")
            {
                this.SetFormIcon(FORMTIP.KULLANICI, "KULLANICI SEÇİM EKRANI");
                var KullaniciListe = manager.GetKullaniciListe(firma);
                listBoxControl1.DataSource = KullaniciListe;
                listBoxControl1.DisplayMember = "kodu";
                listBoxControl1.ValueMember = "kullanicino";
            }
            else if (liste == "dil")
            {
                this.SetFormIcon(FORMTIP.FIRMA, "DİL SEÇİM EKRANI");
                Dictionary<byte, string> DilListe = new Dictionary<byte, string>();
                foreach (RaviDil value in Enum.GetValues(typeof(RaviDil)))
                    DilListe.Add((byte)value, value.ToString());
                listBoxControl1.DataSource = DilListe.ToList();
                listBoxControl1.DisplayMember = "Value";
                listBoxControl1.ValueMember = "Key";
            }
            //listBoxControl1.SelectedIndex = -1;
            listBoxControl1.DoubleClick += ListBox_DoubleClick;
            listBoxControl1.KeyUp += (sender, ev) => { if (ev.KeyCode == Keys.Enter) ListBox_DoubleClick(sender, ev); };
        }
        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            if (liste == "firma")
            {
                if (listBoxControl1.SelectedItem is IRFirmaTb ff)
                    SelectedRow.Invoke(this, ff.kodu);
            }
            else if (liste == "kullanici")
            {
                if (listBoxControl1.SelectedItem is IRKullaniciTb ff)
                    SelectedRow.Invoke(this, ff.kodu.ToString());
            }
            else if (liste == "dil")
            {
                if (listBoxControl1.SelectedItem is KeyValuePair<byte, string> ff)
                {
                    string cevap = "";
                    cevap = "Turkiye";
                    switch (ff.Value)
                    {
                        case "English":
                            cevap = "English";
                            break;
                        case "Arnavut":
                            cevap = "btnArnavut";
                            break;
                        case "Francais":
                            cevap = "France";
                            break;
                        case "Deutsch":
                            cevap = "Germany";
                            break;
                        case "Russian":
                            cevap = "Russia";
                            break;
                        case "Ukraine":
                            cevap = "Ukrayna";
                            break;
                        case "Kirghiz":
                            cevap = "Kirgiz";
                            break;
                        case "Uzbek":
                            cevap = "Ozbek";
                            break;
                        case "Tajik":
                            cevap = "Tacik";
                            break;
                        case "Kazakh":
                            cevap = "Kazak";
                            break;
                        case "Georgian":
                            cevap = "Gurcu";
                            break;
                    }
                    SelectedRow.Invoke(this, cevap);
                }
            }

        }
    }
}
