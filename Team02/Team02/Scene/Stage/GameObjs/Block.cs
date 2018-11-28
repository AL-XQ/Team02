using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;

namespace Team02.Scene.Stage.GameObjs
{
    class Block : GameObj
    {
        public Block(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public override void PreLoadContent()
        {
            IsCrimp = true;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("chat.png");
            base.LoadContent();
        }
    }
}
