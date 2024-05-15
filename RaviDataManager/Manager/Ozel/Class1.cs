using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ravi.Manager
{
    public class DbManager
    {
        public string AktifPos { get; set; }
        public string PosNo { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string RaviFirma { get; set; }
        public int? KullaniciNo { get; set; }
        public string DataAdi { get; set; }
        public string DefaultConnectionString { get; set; }
        public string DefaultFirmaConnectionString { get; set; }
        public SqlConnection dbConSistem { get; set; }
        public SqlConnection dbCon { get; set; }
        public DbManager()
        {
            Load();
        }
        public DbManager(int? KullaniciNo)
        {
            this.KullaniciNo = KullaniciNo;
            Load();
        }
        public DbManager(int? KullaniciNo, string DataAdi)
        {
            this.KullaniciNo = KullaniciNo;
            this.DataAdi = DataAdi;
        }
        public void LoadIni(string yol)
        {
            var rf = ReadIni.IniReadValue("connect", "ravi_firmalar");
            this.RaviFirma = rf.Split(',')[0];
            this.AktifPos = ReadIni.IniReadValue("genel", "aposno");
            this.DefaultConnectionString = ReadIni.IniReadValue("connect", "baglanti");
        }
        public string GetYol()
        {
            string binFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ravi.ini");
            return binFolderPath;
        }
        public void Load()
        {
            LoadIni(GetYol());
            dbConSistem = new SqlConnection(this.DefaultConnectionString);
            if (string.IsNullOrEmpty(RaviFirma)) dbCon = new SqlConnection(this.DefaultConnectionString);
            else dbCon = new SqlConnection(this.DefaultConnectionString.Replace("sistem;", RaviFirma + ";"));
        }
        public void ExFill(Exception ex)
        {
            this.Message = ex.StackTrace;
            this.Message += Environment.NewLine;
            this.Message += ex.Message;
            this.IsSuccess = false;
        }
    }
}
