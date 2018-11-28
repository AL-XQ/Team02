using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage.GameObjs
{
    class KillBlock : Block
    {
        public KillBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara chara)
            {
                chara.Kill();
            }
            base.CalCollision(obj);
        }
    }
}
