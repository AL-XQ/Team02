using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI
{
    public class HideEnemy : Enemy
    {
        public HideEnemy(BaseDisplay aParent, string aName) : base(aParent, aName)
        {

        }

        public HideEnemy(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {

        }

        protected override void SetImage()
        {
            ImageName = "0_0.png";
        }

        public override void CalCollision(StageObj obj)
        {
            
            base.CalCollision(obj);
        }
    }
}
