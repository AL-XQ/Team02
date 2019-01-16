using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;
using Team02;

using InfinityGame.Element;
using InfinityGame;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage
{
    public class MapCreator
    {
        private Base_Stage stage;
        private string heroName;
        private Dictionary<string, object> spawnArgs = new Dictionary<string, object>();
        private D_Void _Update;

        public Base_Stage Stage { get => stage; }
        public Dictionary<string, object> SpawnArgs { get => spawnArgs; }

        public MapCreator(Base_Stage stage)
        {
            this.stage = stage;
        }

        private void CreateObj(Dictionary<string, object> args)
        {
            var type = (Type)args["type"];
            var con = type.GetConstructor(new Type[] { typeof(MapCreator), typeof(Dictionary<string, object>) });
            var obj = (GameObj)con.Invoke(new object[] { this, args });
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
                spawnArgs = args;
                heroName = obj.Name;
                stage.Player.Chara = he;
            }
            obj.Create();
        }

        public void ReSpawn()
        {
            _Update += OnReSpawn;
        }

        private void OnReSpawn()
        {
            if (stage.stageObjs.ContainsKey(heroName))
                return;
            CreateObj(spawnArgs);
            stage.Player.ResetCamera();
            _Update -= OnReSpawn;
        }

        public void Update()
        {
            _Update?.Invoke();
        }

        public void MapRead(object arg)
        {
            if (arg == null)
                return;
            var args = (List<Dictionary<string, object>>)arg;
            foreach (var l in args)
            {
                CreateObj(l);
            }
        }
    }
}
