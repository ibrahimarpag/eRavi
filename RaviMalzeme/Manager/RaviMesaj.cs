using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviMalzeme.Manager
{
    public static class RaviMesaj
    {
        public static void ShowUyari(this Form F, string baslik, string aciklama, string btnText)
        {
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction action = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutAction() { Caption = baslik, Description = aciklama };
            DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand command1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.FlyoutCommand() { Text = btnText, Result = System.Windows.Forms.DialogResult.No };
            action.Commands.Add(command1);
            DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(F, action, null, null);
        }
    }
}
