using DevExpress.XtraEditors;

namespace RaviMalzeme
{
    public class RaviDateEdit : DateEdit
    {
        public RaviDateEdit()
        {
            Default();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            Default();
        }
        private void Default()
        {
            base.Properties.AutoHeight = false;
            base.Height = 22;
            base.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
        }
    }
}
