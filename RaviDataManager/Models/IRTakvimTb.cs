using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Models
{
    public class IRTakvimTb
    {
        [Key]
        public int arefno { get; set; }
        public DateTime zaman_ilk { get; set; }
        public DateTime zaman_son { get; set; }
        public int onay { get; set; }
        public string konu { get; set; }
        public string aciklama { get; set; }
        public string renk { get; set; }
        public int isaret { get; set; }
        public int sms { get; set; }
        public int email { get; set; }
        public int ekran { get; set; }
        public int ekleyen { get; set; }
        public DateTime ekleme_tarih { get; set; }
        public int duzelten { get; set; }
        public DateTime duzeltme_tarih { get; set; }
        public int subeno { get; set; }
        public int tipi { get; set; }
        public int fisno { get; set; }
        public int ceksntno { get; set; }
        public int tekrar { get; set; }
    }
}
