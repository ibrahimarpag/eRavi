using Dapper;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravi.Manager
{
    public class ManagerLogoTicimaxSiparis : DbManager
    {
        public ManagerLogoTicimaxSiparis():base(1)
        {

        }
        public ManagerLogoTicimaxSiparis(int? KullaniciNo) : base(KullaniciNo)
        {

        }
        public List<(string,int)> TicimaxLogoSiparisKontrol(string SiparisNolar)
        {
            List<(string, int)> Data = new List<(string, int)>();
            try
            {
                var query = $@"
SELECT B.DOCODE,
       CASE 
           WHEN L.DOCODE IS NULL THEN 0 
           ELSE 1 
       END AS VarMi
FROM (VALUES {string.Join(", ", SiparisNolar.Split(',').Select(x => $"('{x}')"))}) AS B(DOCODE)
LEFT JOIN (SELECT DISTINCT DOCODE FROM LKSDB..LG_969_01_ORFICHE) AS L ON B.DOCODE = L.DOCODE;";
                Data = base.dbCon.Query<(string, int)>(query).ToList();
            }
            catch (Exception ex)
            {
                base.ExFill(ex);
            }
            return Data;
        }
        public List<VIRSiparisFis> GetList(DateTime? BaslangicTarih = null, DateTime? BitisTarih = null)
        {
            var Data = new List<VIRSiparisFis>();
            try
            {
                Data = base.dbCon.Query<VIRSiparisFis>(@"
SELECT (B.LOGICALREF)fisno,(0)tipi,(B.FICHENO)fisref,(B.DATE_)tarih,('')belge_seri,(B.DOCODE)belge_no,(B.CLIENTREF)carino,(A.CODE)cari_kodu,(A.DEFINITION_)cari_unvani,('')sip_alan,(SELECT CODE FROM LKSDB..LG_969_SHIPINFO WHERE LOGICALREF=B.SHIPINFOREF)sevk_kodu,COUNT(B.FICHENO)sip_adet,AVG(NETTOTAL)net_toplam 
FROM LKSDB..LG_969_01_ORFICHE B with(NoLock)
INNER JOIN LKSDB..LG_969_01_ORFLINE C with(NoLock) ON B.LOGICALREF= C.ORDFICHEREF AND B.STATUS= C.STATUS AND C.AMOUNT> C.SHIPPEDAMOUNT --AND C.CLOSED= 0 --AND C.DUEDATE = '2024-01-01'
INNER JOIN LKSDB..LG_969_CLCARD A with(NoLock) ON C.CLIENTREF= A.LOGICALREF
WHERE LEFT(B.FICHENO,3)='WEB' AND CONVERT(DATE, B.DATE_) BETWEEN @BaslangicTarih AND @BitisTarih --B.TRCODE= 1 AND B.STATUS= 4 --AND B.CYPHCODE = '' AND B.SOURCEINDEX= 0 
GROUP BY B.LOGICALREF,B.FICHENO,B.DATE_,B.DOCODE,B.CLIENTREF,A.CODE,A.DEFINITION_,B.SHIPINFOREF
order by B.LOGICALREF desc", new { BaslangicTarih = BaslangicTarih ?? DateTime.Today, BitisTarih = BitisTarih ?? DateTime.Today }).ToList();
                foreach (var item in Data)
                {
                    item.UrunListe = dbCon.Query<VIRSiparisFisDetay>(@"
SELECT (B.DOCODE)belge_no, (B.SOURCEINDEX)depono,(case when VATINC=0 then 1 else 0 end)kdv_tip,(B.LOGICALREF)fisno,(C.LOGICALREF)sirano,(I.LOGICALREF)stokno,(I.CODE)stok_kodu,(IB.BARCODE)barkodu,(I.NAME)aciklama,(C.UOMREF)birimno,(SELECT CODE FROM LKSDB..LG_969_UNITSETL WHERE LOGICALREF=C.UOMREF)birim_kodu,(C.PRCLISTREF)fiyatno,(C.PRICE)bfiyat,(0.0)isk_1,(0.0)isk_2,(0.0)isk_3,(0.0)isk_4,(0.0)isk_5,(0.0)otv,(C.TOTAL)btutar,(1)adet,(0)miktar,(C.AMOUNT-C.SHIPPEDAMOUNT)sip_miktar,(C.AMOUNT-C.SHIPPEDAMOUNT)kln_miktar,(0)onay,(0)aktar,(0)yazdi 
FROM LKSDB..LG_969_01_ORFICHE B with(NoLock) 
INNER JOIN LKSDB..LG_969_01_ORFLINE C with(NoLock) ON B.LOGICALREF= C.ORDFICHEREF AND B.STATUS= C.STATUS --AND C.CLOSED= 0 AND C.AMOUNT> C.SHIPPEDAMOUNT --AND C.DUEDATE = '2024-01-01' 
INNER JOIN LKSDB..LG_969_ITEMS I with(NoLock) ON C.STOCKREF= I.LOGICALREF 
INNER JOIN LKSDB..LG_969_UNITBARCODE IB with(NoLock) ON I.LOGICALREF= IB.ITEMREF AND IB.BARCODE<> ''
INNER JOIN LKSDB..LG_969_ITMUNITA IA with(NoLock) ON I.LOGICALREF= IA.ITEMREF AND IB.UNITLINEREF= IA.UNITLINEREF AND IB.LINENR= IA.LINENR 
WHERE B.TRCODE= 1 AND B.STATUS= 4 AND B.LOGICALREF = @fisno AND LEFT(B.FICHENO,3)='WEB'
order by B.LOGICALREF desc", item).ToList();
                }
                //Data.ForEach(x => x.tarihStr = (x.tarih ?? DateTime.Today).ToLongDateString());
            }
            catch (Exception ex)
            {
                base.ExFill(ex);
            }
            return Data;
        }
        public List<VIRSiparisFisDetay> GetList(string FNolar)
        {
            var Data = new List<VIRSiparisFisDetay>();
            try
            {
                Data = base.dbCon.Query<VIRSiparisFisDetay>($@"
SELECT 
(I.LOGICALREF)stokno,
(I.CODE)stok_kodu,
(IB.BARCODE)barkodu,
(I.NAME)aciklama,
(C.UOMREF)birimno,
--(SELECT CODE FROM LKSDB..LG_969_UNITSETL WHERE LOGICALREF=C.UOMREF)birim_kodu,
(C.PRCLISTREF)fiyatno,
(C.PRICE)bfiyat,
sum(C.TOTAL)btutar,
sum(C.AMOUNT-C.SHIPPEDAMOUNT)sip_miktar
FROM LKSDB..LG_969_01_ORFICHE B with(NoLock) 
INNER JOIN LKSDB..LG_969_01_ORFLINE C with(NoLock) ON B.LOGICALREF= C.ORDFICHEREF AND B.STATUS= C.STATUS AND C.AMOUNT> C.SHIPPEDAMOUNT --AND C.CLOSED= 0 AND C.AMOUNT> C.SHIPPEDAMOUNT --AND C.DUEDATE = '2024-01-01' 
INNER JOIN LKSDB..LG_969_ITEMS I with(NoLock) ON C.STOCKREF= I.LOGICALREF 
INNER JOIN LKSDB..LG_969_UNITBARCODE IB with(NoLock) ON I.LOGICALREF= IB.ITEMREF AND IB.BARCODE<> ''
INNER JOIN LKSDB..LG_969_ITMUNITA IA with(NoLock) ON I.LOGICALREF= IA.ITEMREF AND IB.UNITLINEREF= IA.UNITLINEREF AND IB.LINENR= IA.LINENR 
WHERE B.TRCODE= 1 AND B.STATUS= 4 AND B.DOCODE IN ({string.Join(",", FNolar.Split(',').Select(x=>$"'{x}'"))}) AND LEFT(B.FICHENO,3)='WEB' AND IB.BARCODE NOT LIKE '%KARGO%'
group by I.LOGICALREF,I.CODE,IB.BARCODE,I.NAME,C.UOMREF   ,C.PRCLISTREF,C.PRICE
").ToList();
            }
            catch (Exception ex)
            {
                base.ExFill(ex);
            }
            return Data;
        }
        
    }
}
