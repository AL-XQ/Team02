using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;
using InfinityGame.Def;
using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        private PlayScene playScene;
        private StageMap stageMap;
        private CharaManager charaManager = new CharaManager();
        public Player Player { get => playScene.Player; }
        public PlayScene PlayScene { get => playScene; }
        public CharaManager CharaManager { get => charaManager; }

        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CameraScale = 1.0f;
            EndOfRightDown = new Vector2(10000, 10000);
            playScene = (PlayScene)parent;
        }



        public override void PreLoadContent()
        {
            Player.Chara = new Hero(this, "hero");
            stageObjs["hero"].Coordinate = new Vector2(0, 200);
            stageObjs["hero"].Size = new Size(64, 64);
            new Block(this, "block");
            stageObjs["block"].Coordinate = new Vector2(300, 400);
            stageObjs["block"].Size = new Size(64, 64);
            new Block(this, "block2");
            stageObjs["block2"].Coordinate = new Vector2(1000, 400);
            stageObjs["block2"].Size = new Size(64 * 2, 64 * 4);
            stageObjs["block2"].Rotation = 0.5f;
            stageObjs["block2"].Origin = (stageObjs["block2"].Size / 2).ToVector2();
            new Block(this, "floor");
            stageObjs["floor"].Coordinate = new Vector2(0, 900 - 64);
            stageObjs["floor"].Size = new Size(1600, 64);
            new Block(this, "top");
            stageObjs["top"].Coordinate = new Vector2(0, 0);
            stageObjs["top"].Size = new Size(1600, 64);
            FocusStageObj = stageObjs["hero"];

            stageMap = new StageMap(this);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
