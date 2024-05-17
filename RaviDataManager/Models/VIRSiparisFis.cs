using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class VIRSiparisFis
    {
        public int subeno { get; set; }
        public short tipi { get; set; }
        public int fisno { get; set; }
        public int? carino { get; set; }
        public short? termno { get; set; }
        public int? depono { get; set; }
        public int? saticino { get; set; }
        public DateTime? tarih { get; set; }
        public byte? iptal { get; set; }
        public byte? kilit { get; set; }
        public byte? ba_tip { get; set; }
        public short? bag_tipi { get; set; }
        public int? bag_fisno { get; set; }
        public short? belge_tip { get; set; }
        public string belge_no { get; set; }
        public string islem_kodu { get; set; }
        public string rapor_kodu { get; set; }
        public string yetki_kodu { get; set; }
        public string proje_kodu { get; set; }
        public string aciklama { get; set; }
        public string icerik_konu { get; set; }
        public DateTime? teslim_tarih { get; set; }
        public string ilgili_kisi { get; set; }
        public byte? kdv_tip { get; set; }
        public byte? isk_tip { get; set; }
        public DateTime? vade_tarih { get; set; }
        public short? ekleyen { get; set; }
        public DateTime? ekleme_tarih { get; set; }
        public short? duzelten { get; set; }
        public DateTime? duzeltme_tarih { get; set; }
        public decimal? isk_g1 { get; set; }
        public decimal? isk_g2 { get; set; }
        public decimal? isk_g3 { get; set; }
        public decimal? isk_g4 { get; set; }
        public decimal? isk_g5 { get; set; }
        public decimal? isk_toplam_g1 { get; set; }
        public decimal? isk_toplam_g2 { get; set; }
        public decimal? isk_toplam_g3 { get; set; }
        public decimal? isk_toplam_g4 { get; set; }
        public decimal? isk_toplam_g5 { get; set; }
        public decimal? tutar_toplam { get; set; }
        public decimal? isk_detay { get; set; }
        public decimal? isk_toplam { get; set; }
        public decimal? ara_toplam { get; set; }
        public decimal? kdv_toplam { get; set; }
        public decimal? yuvarlama { get; set; }
        public decimal? net_toplam { get; set; }
        public double? otv_toplam { get; set; }
        public string belge_seri { get; set; }
        public int? dovizno { get; set; }
        public double? dkur { get; set; }
        public decimal? dnet_toplam { get; set; }
        public short? silen { get; set; }
        public DateTime? silme_tarih { get; set; }
        public short? ent_tipi { get; set; }
        public int? ent_fisno { get; set; }
        public decimal? bag_miktar { get; set; }
        public decimal? bag_net_tutar { get; set; }
        public short? aktif_adres { get; set; }
        public short? e_odm_tip { get; set; }
        public string e_satis_web { get; set; }
        public decimal? ind_toplam { get; set; }
        public string fis_not { get; set; }
        public int? kasano { get; set; }
        public int? bankano { get; set; }


        public string sip_alan {  get; set; }
        public string sevk_kodu {  get; set; }
        public string cari_unvani {  get; set; }
        public string cari_kodu { get; set; }
        public double? sip_adet { get; set; }
        public string fisref { get; set; }

        public List<VIRSiparisFisDetay> UrunListe { get; set; }
    }
    
}
