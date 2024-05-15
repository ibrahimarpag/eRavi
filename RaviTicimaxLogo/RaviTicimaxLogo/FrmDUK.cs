using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Ravi.Manager;
using Ravi.Models.Ozel.Entegrasyon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviTicimaxLogo
{
    //Dökülen Ürünlerin Kontrolü
    public partial class FrmDUK : XtraForm
    {
        List<LogoTicimaxSiparis> Data {  get; set; }
        List<LogoTicimaxSiparisUrun> UrunListe {  get; set; }
        List<LogoTicimaxSiparisUrun> OkutulanUrunListe {  get; set; }
        public FrmDUK(List<LogoTicimaxSiparis> Data)
        {
            this.Data = Data;
            UrunListe = new List<LogoTicimaxSiparisUrun>();
            OkutulanUrunListe = new List<LogoTicimaxSiparisUrun>();
            InitializeComponent();
            gridControl2.DataSource = OkutulanUrunListe;
            gridView1.RowCellStyle += gridView1_RowCellStyle;
            this.ShowInTaskbar = false;
            txtBarkod.Text = "Y06.01.01.086";
            txtBarkod.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //8694432904078
                    if (this.UrunListe.FirstOrDefault(x => x.barkodu == txtBarkod.Text || x.stok_kodu == txtBarkod.Text) is LogoTicimaxSiparisUrun urun)
                    {
                        var index = gridView1.FindRow(urun);
                        if (OkutulanUrunListe.FirstOrDefault(x => x.barkodu == urun.barkodu ) is LogoTicimaxSiparisUrun ourun) 
                        {
                            ourun.sip_miktar++;
                            gridControl2.RefreshDataSource();
                            gridView1.RefreshRow(index);
                        }
                        else
                        {
                            ourun = urun.Copy();
                            ourun.sip_miktar = 1;
                            OkutulanUrunListe.Add(ourun);
                            gridControl2.RefreshDataSource();
                            gridView1.RefreshRow(index);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show($"{txtBarkod.Text} Seçili Sipariş Listelerinde Bulunamadı!");
                    }
                }
            };
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var su = view.GetRow(e.RowHandle) as LogoTicimaxSiparisUrun;
            if (this.OkutulanUrunListe.FirstOrDefault(x => x.barkodu == su.barkodu) is LogoTicimaxSiparisUrun a)
            {
                if (su.sip_miktar == a.sip_miktar) 
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (su.sip_miktar < a.sip_miktar)
                {
                    e.Appearance.BackColor = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
                else e.Appearance.BackColor = Color.LightYellow;
                
                e.Appearance.Options.UseBackColor = true;
            }
            else
            {
                e.Appearance.Options.UseBackColor = false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            foreach (var item in Data)
            {
                foreach (var urun in item.UrunListe)
                {
                    if (UrunListe.FirstOrDefault(x => x.stok_kodu == urun.stok_kodu) is LogoTicimaxSiparisUrun u) 
                    {
                        urun.sip_miktar += u.sip_miktar;
                        urun.btutar += u.btutar;
                    }
                    else
                    {
                        UrunListe.Add(urun);
                    }
                }
            }
            gridControl1.DataSource = UrunListe;
        }
    }
}
