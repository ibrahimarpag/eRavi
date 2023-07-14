using DevExpress.XtraEditors;
using PetekKernel;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviMalzeme.BaseForms
{
    public class BaseListeForm<T> : BasePropertyForm
    {
        public event EventHandler<T> SelectRow = delegate { };
        public event EventHandler<List<T>> SelectRows = delegate { };
        public BaseListeForm()
        {

        }
        public BaseListeForm(Sirket sirket) : base(sirket)
        {
        }
        public void PerformSelectRow(object sender,T row)
        {
            SelectRow.Invoke(sender, row);
        }
        public void PerformSelectRows(object sender, List<T> row)
        {
            SelectRows.Invoke(sender, row);
        }
    }
}
