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

        private void load_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count > 0 && MessageBox.Show("データ破棄！", "警告", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            var res = openF.ShowDialog();
            if (res != DialogResult.OK)
                return;
            data.Rows.Clear();
            string path = openF.FileName;
            string args = File.ReadAllText(path);
            ReadArgs(args);
        }

        private void ReadArgs(string arg)
        {
            List<Dictionary<string, string>> strs = new List<Dictionary<string, string>>();
            string[] split = arg.Split(new char[] { ' ', '\r', '\n', '{' }, StringSplitOptions.None);
            arg = split.Aggregate((str1, str2) => str1 + str2);
            string[] args = arg.Split('}');
            foreach (var l in args)
            {
                if (!l.Contains(';'))
                    continue;
                string[] l_args_t = l.Split(';');
                Dictionary<string, string> l_args = new Dictionary<string, string>();
                foreach (var n in l_args_t)
                {
                    if (!n.Contains('='))
                        continue;
                    string[] n_args = n.Split('=');
                    l_args[n_args[0]] = n_args[1];
                }
                strs.Add(l_args);
            }
            ArgReader(strs);
        }

        private void ArgReader(List<Dictionary<string, string>> strs)
        {
            foreach (var l in strs)
            {
                List<object> args = new List<object>();
                args.Add(l["type"]);
                args.Add(l["coo_x"]);
                args.Add(l["coo_y"]);
                args.Add(l["width"]);
                args.Add(l["height"]);
                if (l.ContainsKey("rota"))
                {
                    args.Add(true);
                    args.Add(l["origin_x"]);
                    args.Add(l["origin_y"]);
                    args.Add(l["rota"]);
                }
                data.Rows.Add(args.ToArray());
            }
        }
    }
}
