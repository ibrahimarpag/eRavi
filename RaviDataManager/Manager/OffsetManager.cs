using Dapper;
using PetekKernel;
using PetekModel;
using RaviDataManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class OffsetManager
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        private SqlConnection dbCon { get; set; }
        private Sirket sirket { get; set; }
        public OffsetManager(Sirket sirket)
        {
            this.sirket = sirket;
            dbCon = new SqlConnection(this.sirket.Baglanti);
        }
        public async Task GetData<T>(int parcaBoyutu, RaviList<T> tablo)
        {
            await Task.Factory.StartNew(async () =>
            {
                int sayfaNo = 1;
                int toplamSatir = GetCount<T>(tablo);
                int parcaSayisi = (int)Math.Ceiling((double)toplamSatir / parcaBoyutu);
                await dbCon.OpenAsync();
                while (sayfaNo <= parcaSayisi)
                {
                    var Veri = new List<T>();
                    var sqlQuery = $"exec dbo.{tablo.StoreProcedureName} {sayfaNo}, {parcaBoyutu}";
                    await Task.Run(async () => { Veri = (await dbCon.QueryAsync<T>(sqlQuery)).ToList(); });
                    tablo.AddRangeR(Veri);
                    sayfaNo++;
                }
                tablo.IsDataLoaded = true;
            });
        }
        public int GetCount<T>(RaviList<T> tablo)
        {
            int count = 0;
            try
            {
                count = dbCon.Query<int>($"select count(*) from {tablo.TableName}").FirstOrDefault();
                IsSuccess = true;
                Message = "";
            }
            catch (Exception ex)
            {
                IsSuccess = false;
                Message = ex.Message;
            }
            return count;
        }
    }
}
