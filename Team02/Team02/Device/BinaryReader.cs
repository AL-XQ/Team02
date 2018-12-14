using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Device
{
    public static class BinaryReader
    {
        public static object ReadMap(string filename)
        {
            try
            {
                string path_0 = "./Map/";
                string path_1 = ".map";
                string path = path_0 + filename + path_1;
                FileStream file = new FileStream(path, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                object data = formatter.Deserialize(file);
                file.Close();
                return data;
            }
            catch
            {
                Console.WriteLine("ファイルがない");
                return null;
            }
        }
    }
}
