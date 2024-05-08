using eRavi.Formlar;
using PetekKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRavi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAnaMenu(new PetekKernel.Sirket(BaglanY.Aktar)));
            //Application.Run(new RaviMalzeme.Form1());
        }
    }
}
