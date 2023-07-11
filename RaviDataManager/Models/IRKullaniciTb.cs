using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    [Table(nameof(IRKullaniciTb))]
    public class IRKullaniciTb
    {
        [Key]
        public int kullanicino { get; set; }
        public string kodu { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public int durum { get; set; }
        public int iptal { get; set; }
        public string sifre { get; set; }
        public string telefon_cep { get; set; }
        public string adres1 { get; set; }
        public DateTime dnm_ilk { get; set; }
        public DateTime dnm_son { get; set; }
        public int donem { get; set; }
        public int ekleyen { get; set; }
        public DateTime ekleme_tarih { get; set; }
        public int duzelten { get; set; }
        public DateTime duzeltme_tarih { get; set; }
        public string firma_yetki { get; set; }
    }
}
