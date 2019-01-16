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
        private float zoom = 1f;
        private float targetZoom = 0.5f;
        private D_Void _RunZoom;
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

        public override void Update(GameTime gameTime)
        {
            if (zoom != 1)
            {
                zoom = 1f;
                _RunZoom = ZoomTo;
            }
            base.Update(gameTime);
        }

        public override void AfterUpdate(GameTime gameTime)
        {
            _RunZoom?.Invoke();
            base.AfterUpdate(gameTime);
        }

        private void ZoomTo()
        {
            var change = (Stage.CameraScale - zoom) * 0.05f;
            if (Math.Abs(change) > 0.0001f)
                Stage.CameraScale -= change;
            else
            {
                Stage.CameraScale = zoom;
                _RunZoom = null;
            }
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero)
            {
                zoom = targetZoom;
                _RunZoom = ZoomTo;
            }
            base.CalCollision(obj);
        }
    }
}
