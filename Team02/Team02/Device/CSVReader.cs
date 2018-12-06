using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Device
{
    class CSVReader
    {
        private List<string[]> stringData=new List<string[]>();
        public CSVReader()
        {
            
        }
        public void Read(string filename,string path="./")
        {

        }
        private void Clear()
        {
            stringData.Clear();
        }
    }
}
