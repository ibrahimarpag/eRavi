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
    public class ManagerSistem
    {
        SqlConnection dbCon { get; set; }
        Sirket sirket { get; set; }
        public ManagerSistem(Sirket sirket)
        {
            this.sirket = sirket;
            dbCon = new SqlConnection(sirket.Baglanti);
        }
        public List<IRKullaniciTb> GetKullaniciListe(string firma)
        {
            List<IRKullaniciTb> Data = new List<IRKullaniciTb>();
            Data = dbCon.Query<IRKullaniciTb>($"SELECT * FROM sistem..tb_kullanici WHERE charindex('{firma}',firma_yetki)>0").ToList();
            return Data;
        }
        public List<IRFirmaTb> GetFirmaListe(string kullanici = "")
        {
            List<IRFirmaTb> Data = new List<IRFirmaTb>();
            Data = dbCon.Query<IRFirmaTb>($"SELECT * FROM sistem..tb_firma {(string.IsNullOrEmpty(kullanici)?"":$"WHERE charindex('{kullanici}',kullanici_yetki)>0")}").ToList();
            return Data;
        }
    }
}
