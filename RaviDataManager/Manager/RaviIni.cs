using PetekKernel;
using System.Runtime.InteropServices;
using System.Text;

namespace RaviDataManager.Manager
{
    public static class RaviIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
         string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);
        public static void IniWriteValue(this Sirket s, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, s.AnaDizin + "\\ravi.ini");
        }

        public static string IniReadValue(this Sirket s, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, s.AnaDizin + "\\ravi.ini");
            return temp.ToString();

        }
    }
}
