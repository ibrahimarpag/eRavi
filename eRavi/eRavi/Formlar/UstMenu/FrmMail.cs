using DevExpress.XtraEditors;
using RaviDataManager;
using RaviMalzeme.Manager;
using RaviMalzeme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaviMalzeme.BaseForms;
using PetekKernel;

namespace eRavi.Formlar.UstMenu
{
    public partial class FrmMail : BasePropertyForm
    {
        public FrmMail(Sirket sirket) : base(sirket)
        {
            InitializeComponent();
            base.ustMenu = new TopStackPanel("Genel Kullanıcı, Hareket Ekstresi Mail.frx", FORMTIP.MAIL);
            this.Controls.Add(ustMenu);
            this.Height += 65;
            base.ustMenu.ClickButton += (sender, e) =>
            {
                if (e == USTMENUBUTTONTIP.KAPAT) this.Close();
            };
            this.SetFormIcon(FORMTIP.MAIL, "MAİL");
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

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
