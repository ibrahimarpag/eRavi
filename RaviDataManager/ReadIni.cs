using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ravi.Manager
{
    public static class ReadIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
           string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);
        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, GetYol());
            return temp.ToString();
        }
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, GetYol());
        }
        public static string GetYol()
        {
            string binFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ravi.ini");
            return binFolderPath;
        }
    }
}
