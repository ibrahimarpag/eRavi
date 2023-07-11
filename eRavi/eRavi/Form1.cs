using DevExpress.XtraEditors;
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

namespace eRavi
{
    public partial class Form1 : XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            simpleButton1.ImageOptions.SetSvgImage("liste", 48, 48);
        }
    }
}
