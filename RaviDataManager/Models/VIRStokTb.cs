using PetekModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class VIRStokTb : IRStokTb
    {
        #region Birim
        public int birimno { get; set; }
        public string birim_kodu { get; set; }
        public string birim_adi { get; set; }
        public double katsayi { get; set; }
        public double katsayi2 { get; set; }
        #endregion
        #region Grup
        public int grupno { get; set; }
        public string grup_adiS { get; set; }
        public int ozelno { get; set; }
        public string ozel_adiS { get; set; }
        public string rapor_grup_adiS { get; set; }
        public string ana_grup_adiS { get; set; }
        public string tali_grup_adiS { get; set; }
        public string alt_grup_adiS { get; set; }
        #endregion
        #region Kategori
        public string kategori { get; set; }
        public string kategori_adi { get; set; }
        #endregion
        #region Kısım
        public string kisim_kodu { get; set; }
        public string kisim_adi { get; set; }
        #endregion
        #region Kullanıcı
        public string kullaniciE { get; set; }
        public string kullanici_adiE { get; set; }
        public string kullaniciD { get; set; }
        public string kullanici_adiD { get; set; }
        #endregion
        #region Fiyat
        public string afiyat_kodu { get; set; }
        public string afiyat_adi { get; set; }
        public string alis_fiyat { get; set; }
        public string alis_dovizno { get; set; }
        public string alis_dkodu { get; set; }
        public string alis_dadi { get; set; }
        public string alis_dfiyat { get; set; }
        public string doviz_afiyat { get; set; }
        public string aisk1 { get; set; }
        public string aisk2 { get; set; }
        public string aisk3 { get; set; }
        public string aisk4 { get; set; }
        public string aisk5 { get; set; }
        public string sfiyat_kodu { get; set; }
        public string sfiyat_adi { get; set; }
        public string satis_fiyat { get; set; }
        public string satis_dovizno { get; set; }
        public string satis_dkodu { get; set; }
        public string satis_dadi { get; set; }
        public string satis_dfiyat { get; set; }
        public string doviz_sfiyat { get; set; }
        public string sisk1 { get; set; }
        public string sisk2 { get; set; }
        public string sisk3 { get; set; }
        public string sisk4 { get; set; }
        public string sisk5 { get; set; }
        #endregion
        #region Miktar
        public string giren { get; set; }
        public string cikan { get; set; }
        public string kmiktar { get; set; }
        public string miktar { get; set; }
        public string giren_tut { get; set; }
        public string cikan_tut { get; set; }
        public string ktutar { get; set; }
        #endregion
        #region Ana Stok
        public string astok_kodu { get; set; }
        public string astok_adi { get; set; }
        #endregion
        #region Cari
        public string teminci_kodu { get; set; }
        public string teminci_unvani { get; set; }
        #endregion
        #region Barkod
        public string barkodu { get; set; }
        public string b_birimno { get; set; }
        public string b_birim { get; set; }
        public string b_katsayi { get; set; }
        public string b_katsayi2 { get; set; }
        public string b_fiyatno { get; set; }
        #endregion
        #region Get
        public string kart_tip_a
        {
            get
            {
                switch (kart_tip)
                {
                    case 1: return "Ürün";
                    case 2: return "Üretim";
                    case 3: return "Hammadde";
                    case 4: return "YarıÜrün";
                    case 5: return "Masraf";
                    default: return "Diğer";
                }
            }
        }
        #endregion
    }
}
