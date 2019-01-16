using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;

namespace Team02.Scene.Stage.GameObjs.Trigger
{
    public abstract class TriggerObj : GameObj
    {
        public TriggerObj(BaseDisplay aParent) : base(aParent)
        {
        }

        public TriggerObj(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {

        }


    }
}
