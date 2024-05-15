using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class FrmSiparisListe : XtraForm
    {
        public IOverlaySplashScreenHandle FLoader { get; set; }
        public void Loader(bool s)
        {
            if (s)
                FLoader = SplashScreenManager.ShowOverlayForm(this);
            else
                SplashScreenManager.CloseOverlayForm(FLoader);
        }
        public FrmSiparisListe()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            tarihIlk.DateTime = DateTime.Today;
            tarihSon.DateTime = DateTime.Today;
            tarihIlk.Properties.MaxValue = DateTime.Today;
            tarihSon.Properties.MaxValue = DateTime.Today;
            btnTarihFiltrele.Click += (s, e) => LoadData();
            btnKontrolEkrani.Click += (s, e) =>
            {
                var SeciliRows = gridView1.GetSelectedRows();
                var Sip = new List<LogoTicimaxSiparis>();
                foreach (var item in SeciliRows)
                {
                    if (gridView1.GetRow(item) is LogoTicimaxSiparis a) Sip.Add(a);
                }
                var frm = new FrmDUK(Sip);
                frm.ShowDialog(this);
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
                ManagerLogoTicimaxSiparis manager = new ManagerLogoTicimaxSiparis(1);
                var SiparisListe = manager.GetList(tarihIlk.DateTime, tarihSon.DateTime);
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
