using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class VIRSiparisFisDetay
    {
        public int subeno { get; set; }
        public short tipi { get; set; }
        public int fisno { get; set; }
        public int? sirano { get; set; }
        public int? depono { get; set; }
        public int? stokno { get; set; }
        public int? saticino { get; set; }
        public DateTime? tarih { get; set; }
        public string barkodu { get; set; }
        public string seri_kodu { get; set; }
        public string aciklama { get; set; }
        public byte? dr_tip { get; set; }
        public byte? ia_tip { get; set; }
        public byte? gc_tip { get; set; }
        public double? mik_en { get; set; }
        public double? mik_by { get; set; }
        public double? mik_ad { get; set; }
        public double? miktar { get; set; }
        public double? teslim_miktar { get; set; }
        public DateTime? teslim_tarih { get; set; }
        public int? birimno { get; set; }
        public double? katsayi { get; set; }
        public int? dovizno { get; set; }
        public double? dkur { get; set; }
        public double? dfiyat { get; set; }
        public int? fiyatno { get; set; }
        public double? bfiyat { get; set; }
        public double? btutar { get; set; }
        public double? tutar { get; set; }
        public double? kdv_orn { get; set; }
        public double? isk_1 { get; set; }
        public double? isk_2 { get; set; }
        public double? isk_3 { get; set; }
        public double? isk_4 { get; set; }
        public double? isk_5 { get; set; }
        public double? isk_g1 { get; set; }
        public double? isk_g2 { get; set; }
        public double? isk_g3 { get; set; }
        public double? isk_g4 { get; set; }
        public double? isk_g5 { get; set; }
        public double? isk_tutar_1 { get; set; }
        public double? isk_tutar_2 { get; set; }
        public double? isk_tutar_3 { get; set; }
        public double? isk_tutar_4 { get; set; }
        public double? isk_tutar_5 { get; set; }
        public double? isk_tutar_g1 { get; set; }
        public double? isk_tutar_g2 { get; set; }
        public double? isk_tutar_g3 { get; set; }
        public double? isk_tutar_g4 { get; set; }
        public double? isk_tutar_g5 { get; set; }
        public double? isk_tutar { get; set; }
        public double? isk_tutar_g { get; set; }
        public double? ara_tutar { get; set; }
        public double? kdv_tutar { get; set; }
        public double? net_tutar { get; set; }
        public double? net_fiyat { get; set; }
        public double? gmiktar { get; set; }
        public double? cmiktar { get; set; }
        public double? gtutar { get; set; }
        public double? ctutar { get; set; }
        public double? katsayi2 { get; set; }
        public double? otv_orn { get; set; }
        public double? otv_tutar { get; set; }
        public string seri_detay { get; set; }
        public byte? sip_kapa { get; set; }
        public double? ind_tutar { get; set; }
        public string proje_kodu { get; set; }
        public string islem_kodu { get; set; }
        public double? islem_puan { get; set; }
        public double? uretim_miktar { get; set; }
        public double? mik_kn { get; set; }
        public double? sip_miktar { get; set; }
        public string stok_kodu { get; set; }
        public string birim_kodu { get; set; }
        public double? adet { get; set; }

        public VIRSiparisFisDetay Copy()
        {
            VIRSiparisFisDetay copy = new VIRSiparisFisDetay();

            foreach (var propertyInfo in typeof(VIRSiparisFisDetay).GetProperties())
            {
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(copy, propertyInfo.GetValue(this));
                }
            }
            return copy;
        }

    }
}
