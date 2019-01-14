using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Device
{
    public static class TextReader
    {
        private static char[] ecole = { '=' };
        private static string[] indention = { ";" };
        public static Dictionary<string, string> Read(string args)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            string[] texts = args.Split(indention, 0);
            foreach (var l in texts)
            {
                if (l.Length > 0)
                {
                    string[] ms = l.Split(ecole);
                    if (ms.Length == 2)
                    {
                        ms[0] = ms[0].Replace(" ", "");
                        ms[1] = ms[1].Replace(" ", "");
                        temp.Add(ms[0], ms[1]);
                    }
                }
            }

            return temp;
        }
    }
}
