using DevExpress.XtraEditors;
using PetekKernel;
using RaviMalzeme.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviMalzeme.BaseForms
{
    public class BasePropertyForm : XtraForm
    {
        public Sirket sirket { get; set; }
        public TopStackPanel ustMenu { get; set; }
        public GridManager managerGrid { get; set; }
        public BasePropertyForm() : base()
        {

        }
        public BasePropertyForm(Sirket sirket) : base()
        {
            this.sirket = sirket;
        }
       
    }
}
