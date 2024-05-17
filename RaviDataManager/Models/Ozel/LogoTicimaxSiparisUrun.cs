//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ravi.Models.Ozel.Entegrasyon
//{
//    public class LogoTicimaxSiparisUrun
//    {
//        public int? depono { get; set; }
//        public int? fisno { get; set; }
//        public int? sirano { get; set; }
//        public int? stokno { get; set; }
//        public int? birimno { get; set; }
//        public string stok_kodu { get; set; }
//        public string barkodu { get; set; }
//        public string aciklama { get; set; }
//        public string birim_kodu { get; set; }
//        public DateTime? tarih { get; set; }
//        public double? bfiyat { get; set; }
//        public double? btutar { get; set; }
//        public double? adet { get; set; }
//        public double? sip_miktar { get; set; }
//        public LogoTicimaxSiparisUrun Copy()
//        {
//            LogoTicimaxSiparisUrun copy = new LogoTicimaxSiparisUrun();

//            foreach (var propertyInfo in typeof(LogoTicimaxSiparisUrun).GetProperties())
//            {
//                if (propertyInfo.CanWrite)
//                {
//                    propertyInfo.SetValue(copy, propertyInfo.GetValue(this));
//                }
//            }
//            return copy;
//        }
//    }
//}
