using PetekKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviTicimaxLogo
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
            ProjectSettings.Yazilim = EYazilim.beyazel;
            Application.Run(new FrmAnaMenu(new PetekKernel.Sirket(BaglanY.Aktar)));
        }
    }
    public static class ProjectSettings
    {
        public static EYazilim Yazilim { get; set; }
    }
}
