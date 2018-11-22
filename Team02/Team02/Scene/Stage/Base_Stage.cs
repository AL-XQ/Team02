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

namespace Team02.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CameraScale = 0.1f;
        }

        public override void PreLoadContent()
        {
            
            base.PreLoadContent();
        }
    }
}
