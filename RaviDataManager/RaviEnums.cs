using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager
{
    public class RaviEnums
    {
    }
    public enum COMBOSTYLE
    {
        NONE,
        EVETHAYIR,
        DOVIZTB,
        DURUM,
        TARTIM,
        HASAT,
        OPERASYON,
        IHBAR,
        CARIKART,
        CARITIP,
        ALISFIYAT,
        SATISFIYAT,
        RISKKONTROL,
        DOVIZTIP,
        YAKITTUR,
        EFATURA,
        SENARYOFATURA,
        SENARYOIRSALIYE,
        EARSIVSEKLI,
        EKURUM,
        EIRSALIYE,
        GIBSENARYO,
        KUCUKBUYUK,
        BANKKARTTIP,
        BANKTIP,
        SATICIKODLISTE,
        BAKIYETUR,
        BOYLAMABOYUT,
        ISYERILISTE,
        DEPOLISTE,
        KASALISTE,
        BANKALISTE,
        SATICILISTE,
        YEMLISTE,
        KAFESLISTE,
        OLUMSEBEP,
        YEDEKONAY,
        KURUSHANE,
        YETKIGOREV,
        GC,
        KULLANICITIP
    }
    public enum RAVIUSTMENU
    {
        NONE = 0,
        SMS = 1,
        MAIL = 2,
        DESTEK = 3,
        TAKVIM = 4,
        HESAP = 5,
        MASAUSTU = 6,
        SISTEM = 7,
        RAPOR = 8,
        YEDEKLE = 9,
        HAKKINDA = 10,
        FIRMA = 11,
        KAPAT = 12
    }
    public enum FORMTIP
    {
        NONE = 0,
        SMS = 1,
        MAIL = 2,
        FIRMA = 3,
        KULLANICI = 4,
        TAKVIM = 5,
        STOK = 6
    }
}
