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
using InfinityGame.Stage.StageObject;

namespace Team02.Scene
{
    public class PlayScene : StageScene
    {
        private StageObj aaaaa;
        private AnimeButton test;
        private AnimeButton test1;
        private AnimeButton test2;
        private Player player;

        public Player Player { get => player; }
        
        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        public override void Initialize()
        {
            if (aaaaa.Stage.Name == "stage2")
                aaaaa.ChangeStage(stages["stage1"]);
            ShowStage = stages["stage1"];
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            player = new Player();
            new Base_Stage(this, "stage1");
            new Base_Stage(this, "stage2");
            aaaaa = new GameObj(stages["stage1"], "aaa");
            stages["stage1"].stageObjs["aaa"].Size = new Size(200, 200);
            stages["stage1"].stageObjs["aaa"].Coordinate = new Vector2(200, 200);
            test = new AnimeButton(this);
            test.Size = size / 5;
            test.Location = new Point(500, 500);

            test1 = new AnimeButton(this);
            test1.Size = size / 5;
            test1.Location = new Point(1000, 500);
            test1.Text = "ステージ変更";
            test2 = new AnimeButton(this);
            test2.Size = size / 5;
            test2.Location = new Point(1000, 700);
            test2.Text = "アイテム転送";
            //stages["stage1"].FocusStageObj = stages["stage1"].stageObjs["aaa"];
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            test.Image = ImageManage.GetSImage("button01");
            test.Click += test_Click;
            test1.Image = ImageManage.GetSImage("button01");
            test1.Click += test1_Click;
            test2.Image = ImageManage.GetSImage("button01");
            test2.Click += test2_Click;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (ShowStage != null)
                test.Text = "タイトルに戻る\nNow:" + ShowStage.Name;
            player.Update(gameTime);
            base.Update(gameTime);
        }
        private void test_Click(object sender, EventArgs e)
        {
            this.IsRun = false;
            GameRun.scenes["title"].IsRun = true;

        }
        private void test1_Click(object sender, EventArgs e)
        {
            if (ShowStage == stages["stage1"])
                ShowStage = stages["stage2"];
            else
                ShowStage = stages["stage1"];
        }


        private void test2_Click(object sender, EventArgs e)
        {
            if (aaaaa.Stage.Name == "stage1")
                aaaaa.ChangeStage(stages["stage2"]);
            else
                aaaaa.ChangeStage(stages["stage1"]);
        }
    }
}
