using PetekKernel;
using RaviDataManager.Manager;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager
{
    public static class TempTable
    {
        public static RaviList<VIRStokTb> StokListe { get; set; }
        public static RaviList<VIRCariTb> CariListe { get; set; }
        public async static void LoadStokListe(Sirket sirket)
        {
            StokListe = new RaviList<VIRStokTb>() { TableName = "tb_stok", StoreProcedureName = "SP_StokListe" };
            StokListesiTakip(sirket);
            OffsetManager offsetManager = new OffsetManager(sirket);
            await offsetManager.GetData<VIRStokTb>(1000, TempTable.StokListe);
        }
        public async static void LoadCariListe(Sirket sirket)
        {
            CariListe = new RaviList<VIRCariTb>() { TableName = "tb_cari", StoreProcedureName = "SP_CariListe" };
            StokListesiTakip(sirket);
            OffsetManager offsetManager = new OffsetManager(sirket);
            await offsetManager.GetData<VIRCariTb>(1000, TempTable.CariListe);
        }
        public static void StokListesiTakip(Sirket sirket)
        {
            //TableWatcher watcher = new TableWatcher("tb_stok", sirket.Baglanti);

            //watcher.TableChanged += (sender, e) =>
            //{
            //    // Değişiklikleri almak için bu event handler'ı kullanabilirsiniz.
            //    var notification = e.Info;
            //    var eventArgs = e;

            //    // İstenilen işlemleri gerçekleştirin.
            //};

            //// Tablodaki değişiklikleri izlemeye başlamak için:
            //watcher.StartWatching();

        }
    }
}
