using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;
using Team02;

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

        private void CreateObj(Dictionary<string, object> args)
        {
            var type = (Type)args["type"];
            var con = type.GetConstructor(new Type[] { typeof(MapCreator), typeof(Dictionary<string, object>) });
            var obj = (GameObj)con.Invoke(new object[] { this, null });
            obj.Coordinate = (SeriVector2)args["coo"];
            if (obj is LoopedBlock lb)
                lb.UnitedSize = (SeriVector2)args["size"];
            else
                obj.Size = (SeriVector2)args["size"];
            if (args.ContainsKey("rota"))
            {
                obj.Origin = (SeriVector2)args["origin"];
                obj.Rotation = (float)args["rota"];
            }
            if (obj is Hero he)
            {
                stage.Player.Chara = he;
            }
            obj.Create();
        }

        public void MapRead(object arg)
        {
            var args = (List<Dictionary<string, object>>)arg;
            foreach(var l in args)
            {
                CreateObj(l);
            }
        }
    }
}
