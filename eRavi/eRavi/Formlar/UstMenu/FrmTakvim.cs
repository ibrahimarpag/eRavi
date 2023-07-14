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
using DevExpress.XtraScheduler;
using RaviDataManager.Manager;
using PetekKernel;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.Drawing;
using RaviMalzeme.BaseForms;

namespace eRavi.Formlar.UstMenu
{
    public partial class FrmTakvim : BasePropertyForm
    {
        public FrmTakvim(Sirket sirket) : base(sirket)
        {
            InitializeComponent();
            base.ustMenu = new TopStackPanel("Takvimde Görev Oluşturulacak", FORMTIP.TAKVIM);
            this.Controls.Add(ustMenu);
            this.Height += 65;
            base.ustMenu.ClickButton += (sender, e) =>
            {
                if (e == USTMENUBUTTONTIP.KAPAT) this.Close();
            };
            schedulerControl1.Start = DateTime.Today;
            schedulerControl1.OptionsView.NavigationButtons.Visibility = NavigationButtonVisibility.Never;
            if (schedulerControl1.ToolTipController != null) 
            {
                schedulerControl1.ToolTipController.Active = false;
            }
            this.SetFormIcon(FORMTIP.TAKVIM, "TAKVİM NOT İŞLEMLERİ");
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            LoadData();
        }
        public void LoadData()
        {
            ManagerTakvim manager = new ManagerTakvim(this.sirket);
            var Data = manager.GetListe();
            foreach (var item in Data)
            {
                Appointment appointment = schedulerControl1.DataStorage.CreateAppointment(AppointmentType.Normal);
                appointment.Subject = item.konu; // başlık sütununu al
                appointment.Description = item.aciklama; // açıklama sütununu al
                appointment.Start = item.zaman_ilk; // başlangıç sütununu al
                appointment.End = item.zaman_son; // bitiş sütununu al
                schedulerControl1.DataStorage.Appointments.Add(appointment);
            }
        }
    }
}
