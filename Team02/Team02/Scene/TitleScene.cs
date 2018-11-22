using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Team02.Scene.UI;

using InfinityGame.UI.UIContent;
using InfinityGame.Device;
using InfinityGame.Device.MouseManage;

namespace Team02.Scene
{
    public class TitleScene : BaseScene
    {
        private MainMenu mainMenu;

        private AnimeButton test;
        private Button test1;

        public TitleScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            mainMenu = new MainMenu(this);
            test = new AnimeButton(this);
            test.Size = size / 5;
            test.Location = new Point(500, 500);
            test.Text = "テストボタン漢字";
            test1 = new Button(this);
            test1.Size = size / 10;
            test1.Location = new Point(300, 300);
            test1.Text = "テスト１";
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            test.Image = ImageManage.GetSImage("button01");
            test1.NormalImage = ImageManage.GetSImage("chat.png");
            test1.DownImage = ImageManage.GetSImage("close_t.png");
            test1.EnterImage = ImageManage.GetSImage("messagebox.png");
            test1.sounds["aa"] = SoundManage.GetSound("click.wav");
            test1.sounds["bb"] = SoundManage.GetSound("enter.wav");
            test1.Click += test1_Click;
            test1.Enter += test1_Enter;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void test1_Click(object sender, EventArgs e)
        {
            test1.sounds["aa"].PlayE();
            GameRun.scenes["title"].IsRun = false;
            GameRun.scenes["play"].IsRun = true;
        }

        private void test1_Enter(object sender, EventArgs e)
        {
            test1.sounds["bb"].PlayE();
        }
    }
}
