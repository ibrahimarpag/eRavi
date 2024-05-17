using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Ravi.Manager;
using RaviDataManager.Manager;
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
    public partial class FrmRaviSiparisListe : XtraForm
    {
        public IOverlaySplashScreenHandle FLoader { get; set; }
        public void Loader(bool s)
        {
            if (s)
                FLoader = SplashScreenManager.ShowOverlayForm(this);
            else
                SplashScreenManager.CloseOverlayForm(FLoader);
        }
        public FrmRaviSiparisListe()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            tarihIlk.DateTime = DateTime.Today;
            tarihSon.DateTime = DateTime.Today;
            tarihIlk.Properties.MaxValue = DateTime.Today;
            tarihSon.Properties.MaxValue = DateTime.Today;
            btnTarihFiltrele.Click += (s, e) => LoadData();
            siparisDurum.SelectedValueChanged += (s, e) =>
            {
                LoadData();
            };
            btnKontrolEkrani.Click += (s, e) =>
            {
                var SeciliRows = gridView1.GetSelectedRows();
                var Sip = new List<VIRSiparisFis>();
                foreach (var item in SeciliRows)
                {
                    if (gridView1.GetRow(item) is VIRSiparisFis a) Sip.Add(a);
                }
                var frm = new FrmDUK(Sip);
                frm.ShowDialog(this);
            };
            siparisDurumDegistir.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(siparisDurumAlt.EditValue?.ToString())) 
                {
                    var SeciliRows = gridView1.GetSelectedRows();
                    var Sip = new List<VIRSiparisFis>();
                    foreach (var item in SeciliRows)
                    {
                        if (gridView1.GetRow(item) is VIRSiparisFis a) Sip.Add(a);
                    }
                    ManagerSiparis manager = new ManagerSiparis(1);
                    manager.SiparisDurumDegistir(Sip, siparisDurumAlt.EditValue?.ToString());
                    LoadData();
                }
            };
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gridView1.OptionsSelection.MultiSelect = true;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            LoadData();
        }
        private void LoadData()
        {
            Loader(true);
            try
            {
                ManagerSiparis manager = new ManagerSiparis(1);
                var SiparisListe = manager.GetList(tarihIlk.DateTime, tarihSon.DateTime, siparisDurum.EditValue.ToString());
                gridControl1.DataSource = SiparisListe;
                gridView2.ViewCaption = "Ürün Listesi";
            }
            catch (Exception)
            {
            }
            finally { Loader(false); }
        }
        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTarihFiltrele_Click(object sender, EventArgs e)
        {

        }
    }
}
