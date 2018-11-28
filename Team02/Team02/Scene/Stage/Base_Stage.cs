using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        private GameObj test;
        private PlayScene playScene;
        public Player Player { get => playScene.Player; }
        public PlayScene PlayScene { get => playScene; }
        
        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CameraScale = 1.0f;
            EndOfRightDown = new Point(10000, 10000);
            playScene = (PlayScene)parent;
        }



        public override void PreLoadContent()
        {
            test = new GameObj(this, "aaa2");
            stageObjs["aaa2"].Size = new Size(200, 200);
            stageObjs["aaa2"].Coordinate = new Vector2(0, 0);
            Player.Chara = new Hero(this, "hero");
            new Enemy(this, "enemy");
            stageObjs["hero"].Coordinate = new Vector2(1100, 1100);
            stageObjs["hero"].Size = new Size(100, 100);
            stageObjs["enemy"].Coordinate = new Vector2(1500, 1100);
            stageObjs["enemy"].Size = new Size(100, 100);
            new Block(this, "block");
            new KillBlock(this, "killblock")
;
            stageObjs["block"].Coordinate = new Vector2(500, 1200);
            stageObjs["block"].Size = new Size(2000, 200);
            stageObjs["killblock"].Coordinate = new Vector2(1000, 1500);
            stageObjs["killblock"].Size = new Size(100, 200);
            FocusStageObj = stageObjs["hero"];
            base.PreLoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
