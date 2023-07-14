using Dapper;
using PetekKernel;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class ManagerTakvim
    {
        SqlConnection dbCon { get; set; }
        Sirket sirket { get; set; }
        public ManagerTakvim(Sirket sirket)
        {
            this.sirket = sirket;
            dbCon = new SqlConnection(sirket.Baglanti);
        }
        public List<IRTakvimTb> GetListe()
        {
            List<IRTakvimTb> Data = new List<IRTakvimTb>();
            Data = dbCon.Query<IRTakvimTb>($"select * from tb_takvim").ToList();
            return Data;
        }
    }
}
