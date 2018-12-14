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
using Team02.Scene.Stage.GameObjs.Actor.AI;
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
            foreach (var l in Types.Keys)
            {
                type.Items.Add(l);
            }
            type.Text = "Block";
            AIPackage.Create();
            foreach (var l in AIPackage.AIs.Keys)
            {
                aicb.Items.Add(l);
            }
        }

        private void addbt_Click(object sender, EventArgs e)
        {
            var objs = new object[] { type.Text, coo_x.Text, coo_y.Text, _width.Text, _height.Text, kon.Checked, origin_x.Text, origin_y.Text, rota.Text, aicb.Text };
            if (masON.Checked)
            {
                float x = float.Parse(coo_x.Text);
                float y = float.Parse(coo_y.Text);
                x *= 64;
                y *= 64;
                objs[1] = x.ToString();
                objs[2] = y.ToString();
            }
            data.Rows.Add(objs);
        }

        private void Save(string path)
        {
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
                var ais = (string)tempArgs["ai"];
                if (ais != "")
                {
                    args["ai"] = ais;
                }
                all_args.Add(args);
            }
            FileStream file = new FileStream(path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, all_args);
            file.Close();
            {
                string cname = openF.SafeFileName;
                string cpath = "Map\\" + cname;
                FileStream cfile = new FileStream(cpath, FileMode.Create);
                BinaryFormatter cformatter = new BinaryFormatter();
                cformatter.Serialize(cfile, all_args);
                cfile.Close();
            }
        }

        private void osave_Click(object sender, EventArgs e)
        {
            string path = openF.FileName;
            if (path == "null")
            {
                MessageBox.Show("ファイルが読み込まれていない！\r\nオーバーライトできない！", "エラー");
                return;
            }
            Save(path);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count == 0)
                return;
            var res = saveF.ShowDialog();
            if (res != DialogResult.OK)
                return;
            string path = saveF.FileName;
            Save(path);
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (data.Rows.Count > 0 && MessageBox.Show("現在作成中のマップは保存されません。", "警告", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
            if (args.ContainsKey("ai"))
            {
                arg_o[9] = args["ai"];
            }
            else
            {
                arg_o[9] = "";
            }
            data.Rows.Add(arg_o);
        }

        private void type_TextChanged(object sender, EventArgs e)
        {
            if (type.Text == "Enemy")
            {
                aicb.Enabled = true;
            }
            else
            {
                aicb.Enabled = false;
            }
        }

        private void rungame_Click(object sender, EventArgs e)
        {
            string path = "Team02.exe";
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(path);
        }

        
    }
}
