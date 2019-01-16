using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;
using Team02.Device;
using Team02.Scene.Stage.GameObjs.Actor;

using InfinityGame;

namespace Team02.Scene.Stage.GameObjs.Trigger
{
    public class CameraZoom : TriggerObj
    {
        private float targetZoom = 0.5f;
        public CameraZoom(BaseDisplay aParent) : base(aParent)
        {
        }

        public CameraZoom(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            if (args.ContainsKey("other"))
            {
                var otherArgs = TextReader.Read((string)args["other"]);
                if (otherArgs.ContainsKey("target"))
                    targetZoom = float.Parse(otherArgs["target"]);
            }
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero)
            {
                base_Stage.Player.ZoomTo(targetZoom);
            }
            base.CalCollision(obj);
        }
    }
}
