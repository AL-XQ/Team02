using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Team02.Device
{
    public static class TextReader
    {
        public static string Read(string filename)
        {
            string path_0 = "./Map/";
            string path_1 = ".map";
            string path = path_0 + filename + path_1;
            return File.ReadAllText(path);
        }
    }
}
