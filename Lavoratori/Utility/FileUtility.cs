using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lavoratori.Utility
{
    public static class FileUtility
    {
        private static XmlSerializer listseri;
        private static string path= ".\\..\\..\\..\\xml";
        private static FileStream fs1;

        public static List<T> Lav<T>(string s)
        {
            string fullPath = Path.Combine(path, s);
            fs1 = File.Open(fullPath, FileMode.Open);
            List<T> listLD = (List<T>)listseri.Deserialize(fs1);
            fs1.Close();
            return listLD;
        }


        public static void InsertList<T>(List<LavoratoreAutonomo> lav,string s)
        {
            listseri = new XmlSerializer(typeof(List<T>));
            string fullPath = Path.Combine(path, s);
            FileStream fs1 = File.Open(fullPath, FileMode.Open);
            listseri.Serialize(fs1, lav);
            fs1.Close();
            
        }
    }
}
