using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;

using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage.GameObjs.Trigger
{
    public class SavePoint : TriggerObj
    {
        public SavePoint(BaseDisplay aParent) : base(aParent)
        {
        }

        public SavePoint(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero)
            {
                base_Stage.MapCreator.SpawnArgs["coo"] = (SeriVector2)Coordinate;
            }
            base.CalCollision(obj);
        }
    }
}
