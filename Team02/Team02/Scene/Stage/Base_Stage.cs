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
        private GameObj test;
        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CameraScale = 1.0f;
            EndOfRightDown = new Point(10000, 10000);
        }

        public override void PreLoadContent()
        {
            test = new GameObj(this, "aaa2");
            stageObjs["aaa2"].Size = new Size(200, 200);
            stageObjs["aaa2"].Coordinate = new Vector2(0, 0);
            base.PreLoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
