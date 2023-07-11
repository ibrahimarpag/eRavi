using DevExpress.Utils;
using DevExpress.XtraEditors;
using RaviDataManager.Models;
using RaviDataManager;

namespace RaviMalzeme
{
    public class CustomSimpleButton : SimpleButton
    {
        public CustomSimpleButton()
        {
            this.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
        }
        public IMenuRw Menu { get; set; }
        public RAVIUSTMENU UstMenuTip { get; set; }
    }
}
