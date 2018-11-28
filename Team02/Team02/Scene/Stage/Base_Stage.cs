using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using Team02.Scene.Stage.GameObjs;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CameraScale = 1f;
            EndOfRightDown = new Point(10000, 10000);
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }
    }
}
