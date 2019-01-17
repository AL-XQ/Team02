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
    public class KillBlock : Block
    {
        public KillBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public KillBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {

        }
        protected override void SetImage()
        {
            ImageName = "DeathBlock.png";   
          //  base.SetImage();
        }
        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara chara)
            {
                chara.Hp -= 50;
            }
            base.CalCollision(obj);
        }
    }
}
