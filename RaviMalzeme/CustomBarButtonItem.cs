using DevExpress.Utils;
using DevExpress.XtraBars;
using RaviDataManager;

namespace RaviMalzeme
{
    public class CustomBarButtonItem : BarButtonItem
    {
        public CustomBarButtonItem()
        {
            this.Appearance.TextOptions.WordWrap = WordWrap.Wrap;

        }
        public RAVIUSTMENU UstMenuTip { get; set; }
    }
}
