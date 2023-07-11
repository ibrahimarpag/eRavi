using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class IRFirmaTb
    {
        public int firmano { get; set; }
        public string kodu { get; set; }
        public string tanim { get; set; }
        public int durum { get; set; }
        public int iptal { get; set; }
        public string veri_dizin { get; set; }
        public DateTime dnm_ilk { get; set; }
        public DateTime dnm_son { get; set; }
        public int donem { get; set; }
        public int ekleyen { get; set; }
        public DateTime ekleme_tarih { get; set; }
        public int duzelten { get; set; }
        public DateTime duzeltme_tarih { get; set; }
        public string kullanici_yetki { get; set; }
        [Write(false)]
        public string firma_adi { get => $"{tanim} ({kodu})"; }
    }
}
