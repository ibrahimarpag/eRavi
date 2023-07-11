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
    public partial class FrmSms : XtraForm
    {
        public FrmSms()
        {
            InitializeComponent();
            this.Controls.Add(new TopStackPanel("Genel Kullanıcı, Hareket Ekstresi.frx", FORMTIP.SMS));
            this.Height += 65;
            this.SetFormIcon(FORMTIP.SMS, "SMS");
            this.Resize += FrmMail_ResizeEnd;
        }
        public void Center()
        {
            panelCenter.Location = new Point(xtraTabPage1.Width / 2 - panelCenter.Width / 2, xtraTabPage1.Height / 2 - panelCenter.Height / 2);
        }
        private void FrmMail_ResizeEnd(object sender, EventArgs e)
        {
            Center();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Application.DoEvents();
            Center();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raviDateEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void raviDateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
