using Dapper;
using Ravi.Manager;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class ManagerSiparis : DbManager
    {
        public ManagerSiparis() : base(1)
        {

        }
        public ManagerSiparis(int? KullaniciNo) : base(KullaniciNo)
        {

        }
        public List<VIRSiparisFis> GetList(DateTime? BaslangicTarih = null, DateTime? BitisTarih = null, string siparisDurum = "")
        {
            var Data = new List<VIRSiparisFis>();
            try
            {
                Data = base.dbCon.Query<VIRSiparisFis>(@"
select cari.cari_unvani,cari.cari_kodu,sip.*,sip.fisno as fisref from tb_siparis_fis as sip
left join tb_cari as cari on (cari.carino=sip.carino)
where sip.tipi=421 and sip.iptal=0 and sip.tarih between @BaslangicTarih AND @BitisTarih
order by fisno desc", new { BaslangicTarih = BaslangicTarih ?? DateTime.Today, BitisTarih = BitisTarih ?? DateTime.Today }).ToList();
                Data.ForEach(x => x.fisref = x.fisno.ToString());
                Data.ForEach(x => x.sip_adet = x.UrunListe?.Sum(a => a.miktar) ?? 0);
                if (siparisDurum== "BEKLEMEDE") Data = Data.Where(x => string.IsNullOrEmpty(x.icerik_konu)).ToList();
                else Data = Data.Where(x => x.icerik_konu == siparisDurum).ToList();
                foreach (var item in Data)
                {
                    item.UrunListe = dbCon.Query<VIRSiparisFisDetay>(@"
select stok.stok_kodu,sipdetay.* from tb_siparis_fisdetay as sipdetay
left join tb_stok as stok on(stok.stokno=sipdetay.stokno)
where tipi=421 and fisno=@fisno", item).ToList();
                    item.UrunListe.ForEach(x => x.sip_miktar = x.miktar);
                }
                //Data.ForEach(x => x.tarihStr = (x.tarih ?? DateTime.Today).ToLongDateString());
            }
            catch (Exception ex)
            {
                base.ExFill(ex);
            }
            return Data;
        }
        public void SiparisDurumDegistir(List<VIRSiparisFis> Data,string siparisDurum)
        {
            try
            {
                var fNos = string.Join(",", Data.Select(x => x.fisno.ToString()).ToArray());
                base.dbCon.Execute($"update tb_siparis_fis set icerik_konu=@siparisDurum where fisno in ({fNos}) and tipi=421", new { siparisDurum });
            }
            catch (Exception ex)
            {
                base.ExFill(ex);
            }
        }
    }
}
