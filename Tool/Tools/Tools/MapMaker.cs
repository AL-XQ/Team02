using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tools
{
    public partial class MapMaker : Form
    {
        public MapMaker()
        {
            InitializeComponent();
        }

        private void addbt_Click(object sender, EventArgs e)
        {
            data.Rows.Add(new object[] { type.Text, coo_x.Text, coo_y.Text, _width.Text, _height.Text, kon.Checked, origin_x.Text, origin_y.Text, rota.Text });
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count == 0)
                return;
            var res = saveF.ShowDialog();
            if (res != DialogResult.OK)
                return;
            string path = saveF.FileName;
            string args = "";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string arg = "{ ";
                bool kon = false;
                for (int j = 0; j < 6; j++)
                {
                    string name = data.Columns[j].HeaderText;
                    if (j == 5)
                    {
                        kon = (bool)data.Rows[i].Cells[j].Value;
                        continue;
                    }
                    string value = (string)data.Rows[i].Cells[j].Value;
                    string arg_0 = $"{name} = {value}; ";
                    arg += arg_0;
                }
                if (kon)
                {
                    for (int j = 6; j < data.ColumnCount; j++)
                    {
                        string name = data.Columns[j].HeaderText;
                        string value = (string)data.Rows[i].Cells[j].Value;
                        string arg_0 = $"{name} = {value}; ";
                        arg += arg_0;
                    }
                }
                arg += "}\r\n";
                args += arg;
            }
            File.WriteAllText(path, args);
        }
    }
}
