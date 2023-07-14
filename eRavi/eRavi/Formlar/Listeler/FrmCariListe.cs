using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using PetekKernel;
using RaviDataManager.Models;
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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using RaviMalzeme.BaseForms;
using DevExpress.XtraGrid.Columns;

namespace eRavi.Formlar.Listeler
{
    public partial class FrmCariListe : BaseListeForm<VIRCariTb>
    {
        public FrmCariListe(Sirket sirket) : base(sirket)
        {
            base.managerGrid = new GridManager(this.sirket);
            InitializeComponent();
            base.ustMenu = new TopStackPanel("Cari Liste", FORMTIP.CARILISTE);
            this.Controls.Add(base.ustMenu);
            progressLoader.Visible = true;
            this.FormClosing += FrmCariListe_FormClosing;
            this.gridControl1.RaviButtonCustomizationForm = true;
            this.gridView1.GridFTip = GRIDFTIP.CARI;
            this.gridView1.GridEKey = GRIDEKEY.LISTE;
            this.gridControl1.RaviButtonCustomizationForm = true;
            this.gridView1.DoubleClick += (sender, e) =>
            {
                DXMouseEventArgs ea = e as DXMouseEventArgs;
                GridView view = sender as GridView;
                GridHitInfo info = view.CalcHitInfo(ea.Location);
                if (info.InRow || info.InRowCell)
                {
                    if (this.gridView1.GetRow(info.RowHandle) is VIRCariTb cari) base.PerformSelectRow(this, cari);
                    //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                    //MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                }
            };
            base.ustMenu.ClickButton += (sender, e) =>
            {
                if (e==USTMENUBUTTONTIP.KAPAT) this.Close();
            };
        }

        private void CariListe_Completed(object sender, EventArgs e)
        {
            progressLoader.Visible = false;
        }

        private void CariListe_AddRows(object sender, List<VIRCariTb> e)
        {
            gridControl1.RefreshDataSource();
        }

        private void FrmCariListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            TempTable.CariListe.AddRows -= CariListe_AddRows;
            TempTable.CariListe.Completed -= CariListe_Completed;
            base.managerGrid.SaveGridColumns(this.gridView1);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetFormIcon(FORMTIP.CARILISTE, "Cari Listesi");
            TempTable.CariListe.AddRows += CariListe_AddRows;
            TempTable.CariListe.Completed += CariListe_Completed;
            progressLoader.Visible = !TempTable.CariListe.IsDataLoaded;
            KolonYukle();
            ListeYukle();
        }
        private void KolonYukle()
        {
            base.managerGrid.FillGridColumns(this.gridView1);
            if (gridView1.Columns["carino"] is GridColumn g)
            {
                g.VisibleIndex = 0;
                g.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                g.SummaryItem.DisplayFormat = "Toplam: {0}";
            }
            
        }
        private void ListeYukle()
        {
            gridControl1.DataSource = TempTable.CariListe;
        }
    }
}
