using Dapper;
using PetekKernel;
using PetekModel;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class ManagerTanim
    {
        SqlConnection dbCon { get; set; }
        Sirket sirket { get; set; }
        public ManagerTanim(Sirket sirket)
        {
            this.sirket = sirket;
        //    dbCon = new SqlConnection(sirket.Baglanti);
        }
        public List<IRTanimTb> GetListe(CariTanim cariTanim)
        {
            List<IRTanimTb> Data = new List<IRTanimTb>();
            //    Data = dbCon.Query<IRTanimTb>($"select * from tb_tanim where reftip=@reftip", new { reftip = (int)cariTanim }).ToList();
            return Data;
        }
    }
}
