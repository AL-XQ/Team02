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
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;
using Team02;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tools
{
    public partial class MapMaker : Form
    {
        public static Dictionary<string, Type> Types = new Dictionary<string, Type>()
        {
            {"Block",typeof(Block) },
            {"KillBlock",typeof(KillBlock) },
            {"Hero",typeof(Hero) },
            {"Enemy",typeof(Enemy) },
        };

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
            List<Dictionary<string, object>> all_args = new List<Dictionary<string, object>>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var tempArgs = new Dictionary<string, object>();
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    string name = data.Columns[j].HeaderText;
                    object value;
                    if (name == "Expansion")
                        value = (bool)data.Rows[i].Cells[j].Value;
                    else
                        value = data.Rows[i].Cells[j].Value;
                    tempArgs.Add(name, value);
                }
                SeriVector2 GetVector2(string s0, string s1)
                {
                    return new SeriVector2(float.Parse((string)tempArgs[s0]), float.Parse((string)tempArgs[s1]));
                }
                bool kon = (bool)tempArgs["Expansion"];
                var args = new Dictionary<string, object>();
                args["type"] = Types[(string)tempArgs["type"]];
                args["coo"] = GetVector2("coo_x", "coo_y");
                args["size"] = GetVector2("width", "height");
                if (kon)
                {
                    args["origin"] = GetVector2("origin_x", "origin_y");
                    args["rota"] = float.Parse((string)tempArgs["rota"]);
                }
                all_args.Add(args);
            }
            FileStream file = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, all_args);
            file.Close();
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
            FileStream file = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            object data_o = formatter.Deserialize(file);
            file.Close();
            FileRead(data_o);
        }

        private void FileRead(object arg)
        {
            var args = (List<Dictionary<string, object>>)arg;
            foreach (var l in args)
            {
                ReadObj(l);
            }
        }

        private void ReadObj(Dictionary<string, object> args)
        {
            var type = args["type"].ToString();
            string[] type_c = type.Split('.');
            type = type_c[type_c.Length - 1];
            var coo = (SeriVector2)args["coo"];
            var size = (SeriVector2)args["size"];
            object[] arg_o = new object[data.ColumnCount];
            arg_o[0] = type;
            arg_o[1] = coo.x.ToString();
            arg_o[2] = coo.y.ToString();
            arg_o[3] = size.x.ToString();
            arg_o[4] = size.y.ToString();
            if (args.ContainsKey("rota"))
            {
                arg_o[5] = true;
                var origin = (SeriVector2)args["origin"];
                arg_o[6] = origin.x.ToString();
                arg_o[7] = origin.y.ToString();
                var rota = args["rota"];
                arg_o[8] = rota.ToString();
            }
            else
            {
                arg_o[5] = false;
                arg_o[6] = "";
                arg_o[7] = "";
                arg_o[8] = "";
            }
            data.Rows.Add(arg_o);
        }
    }
}
