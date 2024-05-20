using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Ravi.Manager;
using RaviDataManager.Models;
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
        List<VIRSiparisFis> Data {  get; set; }
        List<VIRSiparisFisDetay> UrunListe {  get; set; }
        List<VIRSiparisFisDetay> OkutulanUrunListe {  get; set; }
        public FrmDUK(List<VIRSiparisFis> Data)
        {
            this.Data = Data;
            UrunListe = new List<VIRSiparisFisDetay>();
            OkutulanUrunListe = new List<VIRSiparisFisDetay>();
            InitializeComponent();
            timerBarkod.Tick += (s, e) =>
            {
                if (!gridControl1.IsFocused && barkodOdaklama.Checked) txtBarkod.Focus();
            };
            gridControl2.DataSource = OkutulanUrunListe;
            gridView1.RowCellStyle += gridView1_RowCellStyle;
            secenekCikar.CheckedChanged += (s, e) => txtBarkod.Focus();
            this.ShowInTaskbar = false;
            //txtBarkod.Text = "Y06.01.01.086";
            txtBarkod.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtBarkod.Text))
                {
                    //8694432904078
                    if (this.UrunListe.FirstOrDefault(x => (x.barkodu == txtBarkod.Text && !string.IsNullOrEmpty(x.barkodu)) || x.stok_kodu == txtBarkod.Text) is VIRSiparisFisDetay urun)
                    {
                        var index = gridView1.FindRow(urun);
                        if (OkutulanUrunListe.FirstOrDefault(x => (x.barkodu == txtBarkod.Text && !string.IsNullOrEmpty(x.barkodu)) || x.stok_kodu == txtBarkod.Text) is VIRSiparisFisDetay ourun)
                        {
                            if (secenekCikar.Checked)
                            {
                                ourun.sip_miktar--;
                                if (ourun.sip_miktar == 0)
                                    OkutulanUrunListe.Remove(ourun);
                                secenekCikar.Checked = false;
                            }
                            else ourun.sip_miktar++;
                            gridControl2.RefreshDataSource();
                            gridView1.RefreshRow(index);
                        }
                        else if (!secenekCikar.Checked) 
                        {
                            ourun = urun.Copy();
                            ourun.sip_miktar = 1;
                            OkutulanUrunListe.Add(ourun);
                            gridControl2.RefreshDataSource();
                            gridView1.RefreshRow(index);
                        }
                        else if (secenekCikar.Checked) XtraMessageBox.Show($"Çıkarmak İstediğiniz Ürün 'Okutulan Ürünler' Arasında Bulunamadı!");
                    }
                    else
                    {
                        XtraMessageBox.Show($"{txtBarkod.Text} Seçili Sipariş Listelerinde Bulunamadı!");
                    }
                    txtBarkod.Text = string.Empty;
                }
            };
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var su = view.GetRow(e.RowHandle) as VIRSiparisFisDetay;
            var k = string.IsNullOrEmpty(su.barkodu) ? su.stok_kodu : su.barkodu;
            if (this.OkutulanUrunListe.FirstOrDefault(x => x.barkodu == k || x.stok_kodu == k) is VIRSiparisFisDetay a) 
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
                    if (UrunListe.FirstOrDefault(x => x.stok_kodu == urun.stok_kodu) is VIRSiparisFisDetay u) 
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
