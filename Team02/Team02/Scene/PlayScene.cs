using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Team02.Scene.Stage;
using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene
{
    public class PlayScene : StageScene
    {
        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            new Base_Stage(this, "stage1");
            new Base_Stage(this, "stage2");
            ShowStage = stages["stage1"];
            new GameObj(stages["stage1"], "aaa");
            stages["stage1"].stageObjs["aaa"].Size = new Size(200, 200);
            stages["stage1"].FocusStageObj = stages["stage1"].stageObjs["aaa"];

            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
