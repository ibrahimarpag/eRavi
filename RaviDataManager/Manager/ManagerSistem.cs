using Dapper;
using PetekKernel;
using PetekModel;
using Ravi.Manager;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviDataManager.Manager
{
    public class ManagerSistem : DbManager
    {
        public List<IRKullaniciTb> GetKullaniciListe(string firma)
        {
            List<IRKullaniciTb> Data = new List<IRKullaniciTb>();
            Data = dbConSistem.Query<IRKullaniciTb>($"SELECT * FROM sistem..tb_kullanici WHERE charindex('{firma}',firma_yetki)>0").ToList();
            return Data;
        }
        public List<IRFirmaTb> GetFirmaListe(string kullanici = "")
        {
            List<IRFirmaTb> Data = new List<IRFirmaTb>();
            Data = dbConSistem.Query<IRFirmaTb>($"SELECT * FROM sistem..tb_firma {(string.IsNullOrEmpty(kullanici) ? "" : $"WHERE charindex('{kullanici}',kullanici_yetki)>0")}").ToList();
            return Data;
        }
    }
}
