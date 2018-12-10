using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;

using InfinityGame.Element;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage
{
    public class MapCreator
    {
        public static Dictionary<string, Type> Types = new Dictionary<string, Type>()
        {
            {"Block",typeof(Block) },
            {"KillBlock",typeof(KillBlock) },
            {"Hero",typeof(Hero) },
            {"Enemy",typeof(Enemy) },
        };
        private Base_Stage stage;

        public Base_Stage Stage { get => stage; }
        public MapCreator(Base_Stage stage)
        {
            this.stage = stage;
        }

        private void CreateObj(Type type, Dictionary<string, object> args)
        {
            var con = type.GetConstructor(new Type[] { typeof(MapCreator), typeof(Dictionary<string, object>) });
            var obj = (GameObj)con.Invoke(new object[] { this, null });
            obj.Coordinate = (Vector2)args["coo"];
            if (obj is LoopedBlock lb)
                lb.UnitedSize = (Size)args["size"];
            else
                obj.Size = (Size)args["size"];
            if (args.ContainsKey("rota"))
            {
                obj.Origin = (Vector2)args["origin"];
                obj.Rotation = (float)args["rota"];
            }
            if (obj is Hero he)
            {
                stage.Player.Chara = he;
            }
            obj.Create();
        }

        private void CreateMap(List<object[]> args)
        {
            foreach (var l in args)
            {
                CreateObj((Type)l[0], (Dictionary<string, object>)l[1]);
            }
        }

        private void ArgReader(List<Dictionary<string, string>> strs)
        {
            List<object[]> args = new List<object[]>();
            foreach (var l in strs)
            {
                object[] arg = new object[2];
                var type = Types[l["type"]];
                arg[0] = type;
                Dictionary<string, object> objArgs = new Dictionary<string, object>();
                objArgs["coo"] = new Vector2(float.Parse(l["coo_x"]), float.Parse(l["coo_y"]));
                objArgs["size"] = new Size(int.Parse(l["width"]), int.Parse(l["height"]));
                if (l.ContainsKey("rota"))
                {
                    objArgs["origin"] = new Vector2(float.Parse(l["origin_x"]), float.Parse(l["origin_y"]));
                    objArgs["rota"] = float.Parse(l["rota"]);
                }
                arg[1] = objArgs;
                args.Add(arg);
            }
            CreateMap(args);
        }

        public void MapReader(string arg)
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
    }
}
