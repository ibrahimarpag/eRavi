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

namespace eRavi.Formlar.UstMenu
{
    public partial class FrmTakvim : XtraForm
    {
        public FrmTakvim()
        {
            InitializeComponent();
            schedulerControl1.Start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.Controls.Add(new TopStackPanel("Takvimde Görev Oluşturulacak", FORMTIP.TAKVIM));
            this.Height += 65;
            this.SetFormIcon(FORMTIP.TAKVIM, "TAKVİM NOT İŞLEMLERİ");
        }
    }
}
