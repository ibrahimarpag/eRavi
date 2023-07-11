

using RaviDataManager;
using System.Linq;

namespace RaviMalzeme
{
    public class RaviLookUpEdit : DevExpress.XtraEditors.LookUpEdit
    {
        public bool RaviAutoLoad { get; set; } = false;
        private COMBOSTYLE RLT { get; set; } = COMBOSTYLE.NONE;
        public COMBOSTYLE RaviListeTip
        {
            get
            {
                return RLT;
            }
            set
            {
                RLT = value;
            }
        }
        public RaviLookUpEdit() : base()
        {
            Default();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            Default();
            if (RaviAutoLoad)
            {
                base.Properties.Columns.Clear();
                LoadData();
            }
            base.Properties.AllowFocused = false;
        }
        private void Default()
        {
            base.Properties.AutoHeight = false;
            base.Height = 22;
            base.Properties.NullText = "";
        }
        public void LoadData()
        {
            switch (RaviListeTip)
            {
                case COMBOSTYLE.NONE:
                    break;
                case COMBOSTYLE.EVETHAYIR:
                    break;
                case COMBOSTYLE.DOVIZTB:
                    break;
                case COMBOSTYLE.DURUM:
                    {
                        base.Properties.DataSource = PetekKernel.PetekRapor.sen.GetDurum().ToList();
                        base.Properties.DisplayMember = "Value";
                        base.Properties.ValueMember = "Key";
                        base.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = "", FieldName = "Value" });
                    }
                    break;
                case COMBOSTYLE.TARTIM:
                    break;
                case COMBOSTYLE.HASAT:
                    break;
                case COMBOSTYLE.OPERASYON:
                    break;
                case COMBOSTYLE.IHBAR:
                    break;
                case COMBOSTYLE.CARIKART:
                    break;
                case COMBOSTYLE.CARITIP:
                    break;
                case COMBOSTYLE.ALISFIYAT:
                    break;
                case COMBOSTYLE.SATISFIYAT:
                    break;
                case COMBOSTYLE.RISKKONTROL:
                    break;
                case COMBOSTYLE.DOVIZTIP:
                    break;
                case COMBOSTYLE.YAKITTUR:
                    break;
                case COMBOSTYLE.EFATURA:
                    break;
                case COMBOSTYLE.SENARYOFATURA:
                    break;
                case COMBOSTYLE.SENARYOIRSALIYE:
                    break;
                case COMBOSTYLE.EARSIVSEKLI:
                    break;
                case COMBOSTYLE.EKURUM:
                    break;
                case COMBOSTYLE.EIRSALIYE:
                    break;
                case COMBOSTYLE.GIBSENARYO:
                    break;
                case COMBOSTYLE.KUCUKBUYUK:
                    break;
                case COMBOSTYLE.BANKKARTTIP:
                    break;
                case COMBOSTYLE.BANKTIP:
                    break;
                case COMBOSTYLE.SATICIKODLISTE:
                    break;
                case COMBOSTYLE.BAKIYETUR:
                    break;
                case COMBOSTYLE.BOYLAMABOYUT:
                    break;
                case COMBOSTYLE.ISYERILISTE:
                    break;
                case COMBOSTYLE.DEPOLISTE:
                    break;
                case COMBOSTYLE.KASALISTE:
                    break;
                case COMBOSTYLE.BANKALISTE:
                    break;
                case COMBOSTYLE.SATICILISTE:
                    break;
                case COMBOSTYLE.YEMLISTE:
                    break;
                case COMBOSTYLE.KAFESLISTE:
                    break;
                case COMBOSTYLE.OLUMSEBEP:
                    break;
                case COMBOSTYLE.YEDEKONAY:
                    break;
                case COMBOSTYLE.KURUSHANE:
                    break;
                case COMBOSTYLE.YETKIGOREV:
                    break;
                case COMBOSTYLE.GC:
                    break;
                case COMBOSTYLE.KULLANICITIP:
                    break;
                default:
                    break;
            }
        }
    }
}
