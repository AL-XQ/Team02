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
using InfinityGame.Device;

using InfinityGame.UI.UIContent;
using InfinityGame.Device.MouseManage;

namespace Team02.Scene
{
    public class PlayScene : StageScene
    {
        private AnimeButton test;
        private Player player;

        public Player Player { get => player; }

        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            player = new Player();
            new Base_Stage(this, "stage1");
            new Base_Stage(this, "stage2");
            ShowStage = stages["stage1"];
            new GameObj(stages["stage1"], "aaa");
            stages["stage1"].stageObjs["aaa"].Size = new Size(200, 200);
            stages["stage1"].stageObjs["aaa"].Coordinate = new Vector2(200, 200);
            //stages["stage1"].FocusStageObj = stages["stage1"].stageObjs["aaa"];
            test = new AnimeButton(this);
            test.Size = size / 5;
            test.Location = new Point(500, 500);
            test.Text = "タイトルに戻る";
            stages["stage1"].FocusStageObj = stages["stage1"].stageObjs["aaa"];
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            test.Image= ImageManage.GetSImage("button01");
            test.Click+= test_Click;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            base.Update(gameTime);
        }
        private void test_Click(object sender,EventArgs e)
        {
            this.IsRun = false;
            GameRun.scenes["title"].IsRun = true;

        }
    }
}
