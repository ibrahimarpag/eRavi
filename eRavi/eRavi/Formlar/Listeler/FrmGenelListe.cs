using PetekKernel;
using RaviDataManager;
using RaviMalzeme.Manager;
using System;
using RaviMalzeme;
using RaviDataManager.Manager;
using RaviMalzeme.BaseForms;
using PetekModel;

namespace eRavi.Formlar.Listeler
{
    public partial class FrmTanimListe : BaseListeForm<IRTanimTb>
    {
        private CariTanim cariTanim { get; set; }
        public FrmTanimListe(Sirket sirket, string Text, FORMTIP formTip, GRIDFTIP gridFTip, GRIDEKEY gridEKey, CariTanim cariTanim) : base(sirket)
        {
            this.cariTanim = cariTanim;
            base.managerGrid = new GridManager(base.sirket);
            InitializeComponent();
            this.ShowInTaskbar = false;
            base.ustMenu = new TopStackPanel(Text, formTip);
            this.Controls.Add(base.ustMenu);
            this.Height += 65;
            progressLoader.Visible = true;
            this.SetFormIcon(formTip, Text);
            this.gridView1.GridFTip = gridFTip;
            this.gridView1.GridEKey = gridEKey;
            this.gridControl1.RaviButtonCustomizationForm = true;
            ustMenu.ClickButton += (sender, e) =>
            {
                if (e == USTMENUBUTTONTIP.KAPAT) this.Close();
                else if (e == USTMENUBUTTONTIP.SEC)
                    if (this.gridView1.FocusedRowHandle >= 0)
                        if (this.gridView1.GetRow(this.gridView1.FocusedRowHandle) is IRTanimTb row) base.PerformSelectRow(this, row);
            };
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            base.managerGrid.FillGridColumns(this.gridView1);
            LoadData();
        }
        private void LoadData()
        {
            ManagerTanim manager = new ManagerTanim(this.sirket);
            var Data = manager.GetListe(cariTanim);
            gridControl1.DataSource = Data;
            progressLoader.Visible = false;
        }
    }
}
