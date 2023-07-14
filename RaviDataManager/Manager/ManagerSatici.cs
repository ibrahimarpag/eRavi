using Dapper;
using PetekKernel;
using PetekModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class ManagerSatici
    {
        SqlConnection dbCon { get; set; }
        Sirket sirket { get; set; }
        public ManagerSatici(Sirket sirket)
        {
            this.sirket = sirket;
            dbCon = new SqlConnection(sirket.Baglanti);
        }
        public List<IRSaticiTb> GetListe()
        {
            List<IRSaticiTb> Data = new List<IRSaticiTb>();
            Data = dbCon.Query<IRSaticiTb>($"select * from tb_satici").ToList();
            return Data;
        }
        public IRSaticiTb Get(int saticino)
        {
            IRSaticiTb Data = new IRSaticiTb();
            Data = dbCon.Query<IRSaticiTb>($"select * from tb_satici where saticino=@saticino", new { saticino }).FirstOrDefault();
            return Data;
        }
    }
}
