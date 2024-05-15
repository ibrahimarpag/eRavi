using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravi.Models.Ozel.Entegrasyon
{
    public class LogoTicimaxSiparis
    {
        public int? fisno { get; set; }
        public int? tipi { get; set; }
        public string fisref { get; set; }
        public DateTime? tarih { get; set; }
        public string tarihStr { get; set; }
        public string belge_seri { get; set; }
        public string belge_no { get; set; }
        public int? carino { get; set; }
        public string cari_kodu { get; set; }
        public string cari_unvani { get; set; }
        public string sip_alan { get; set; }
        public string sevk_kodu { get; set; }
        public int? sip_adet { get; set; }
        public string net_toplam { get; set; }
        public List<LogoTicimaxSiparisUrun> UrunListe { get; set; }
    }
}
