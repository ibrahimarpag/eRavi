using DevExpress.XtraEditors;
using PetekKernel;
using PetekModel;
using RaviDataManager.Manager;
using RaviDataManager;
using RaviMalzeme.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaviDataManager.Models;
using RaviMalzeme;
using RaviMalzeme.BaseForms;

namespace eRavi.Formlar.Listeler
{
    public partial class FrmStokListe : BasePropertyForm
    {
        
        public FrmStokListe(Sirket sirket) : base (sirket)
        {
            base.managerGrid = new GridManager(this.sirket);
            InitializeComponent();
            ustMenu = new TopStackPanel("Stok Liste", FORMTIP.STOKLISTE);
            this.Controls.Add(ustMenu);
            
            progressLoader.Visible = true;
            this.FormClosing += FrmStokListe_FormClosing;
            this.SetFormIcon(FORMTIP.STOK, "Stok Listesi");
            TempTable.StokListe.AddRows += StokListe_AddRows;
            TempTable.StokListe.Completed += StokListe_Completed;
            progressLoader.Visible = !TempTable.StokListe.IsDataLoaded;
            this.gridView1.GridFTip = GRIDFTIP.STOK;
            this.gridView1.GridEKey = GRIDEKEY.LISTE;
            this.gridControl1.RaviButtonCustomizationForm = true;
            //(new SqlConnection(sirket.Baglanti)).Execute("update tb_stok set stok_adi=stok_adi+' 1' where stokno=5");
            ustMenu.ClickButton += (sender, e) =>
            {
            };
        }

        private void StokListe_Completed(object sender, EventArgs e)
        {
            progressLoader.Visible = false;
        }

        private void StokListe_AddRows(object sender, List<VIRStokTb> e)
        {
            gridControl1.RefreshDataSource();
        }

        private void FrmStokListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            TempTable.StokListe.AddRows -= StokListe_AddRows;
            TempTable.StokListe.Completed -= StokListe_Completed;
            base.managerGrid.SaveGridColumns(this.gridView1);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            KolonYukle();
            ListeYukle();
        }
        private void KolonYukle()
        {
            base.managerGrid.FillGridColumns(this.gridView1);

            gridView1.Columns["stokno"].VisibleIndex = 0;
            gridView1.Columns["stokno"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns["stokno"].SummaryItem.DisplayFormat = "Toplam: {0}";
        }
        private void ListeYukle()
        {
            gridControl1.DataSource = TempTable.StokListe;
        }
    }
}
