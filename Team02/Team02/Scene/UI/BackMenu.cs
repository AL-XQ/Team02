using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.GameGraphics;
using InfinityGame.UI.UIContent;
using InfinityGame.UI;

using Microsoft.Xna.Framework;
using InfinityGame.Element;
using InfinityGame.Device;
using Microsoft.Xna.Framework.Input;
using InfinityGame;

namespace Team02.Scene.UI
{
    public class BackMenu : UIWindow
    {
        private AnimeButton back;
        private AnimeButton reset;
        private AnimeButton title;
        private AnimeButton exit;
        private List<AnimeButton> buts = new List<AnimeButton>();
        private int index = 0;

        private int Index { get => index; set => SetIndex(value); }
        public BackMenu(BaseDisplay parent) : base(parent)
        {
            BorderOn = false;
            CanClose = false;
            CanMove = false;
            backColor = Color.Transparent;
        }

        private void SetIndex(int value)
        {
            int t = value;
            if (t == -1)
                t = buts.Count - 1;
            else if (t == buts.Count)
                t = 0;
            buts[index].OnLeave(null, null);
            index = t;
            buts[index].OnEnter(null, null);

        }
        public override void Initialize()
        {
            Index = 0;
            visible = false;
            base.Initialize();
        }
        private void RegistEvent()
        {
            title.Click += Title;
            reset.Click += Reset;
            exit.Click += Exit;
            back.Click += Back;
        }
        public override void PreLoadContent()
        {
            Size = new Size(parent.Size.Width * 2 / 7, parent.Size.Height * 3 / 7);
            Location = (parent.Size / 2 - Size / 2).ToPoint();
            back = new AnimeButton(graphicsDevice, this);
            buts.Add(back);
            reset = new AnimeButton(graphicsDevice, this);
            buts.Add(reset);
            title = new AnimeButton(graphicsDevice, this);
            buts.Add(title);
            exit = new AnimeButton(graphicsDevice, this);
            buts.Add(exit);

            back.Size = new Size(Size.Width * 4 / 5, Size.Height / 5);
            reset.Size = back.Size;
            title.Size = back.Size;
            exit.Size = back.Size;
            back.Location = new Point(size.Width / 2 - back.Size.Width / 2, 30);
            reset.Location = back.Location + new Point(0, back.Size.Height + 10);
            title.Location = reset.Location + new Point(0, reset.Size.Height + 10);
            exit.Location = title.Location + new Point(0, title.Size.Height + 10);

            RegistEvent();
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            back.Text = GetText("Back");
            reset.Text = GetText("Reset");
            title.Text = GetText("Title");
            exit.Text = GetText("Exit");
            back.BDText.ForeColor = System.Drawing.Color.White;
            reset.BDText.ForeColor = System.Drawing.Color.White;
            title.BDText.ForeColor = System.Drawing.Color.White;
            exit.BDText.ForeColor = System.Drawing.Color.White;
            back.TextAlign = ContentAlignment.MiddleCenter;
            reset.TextAlign = ContentAlignment.MiddleCenter;
            title.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;
            back.Image = ImageManage.GetSImage("button");
            reset.Image = back.Image;
            title.Image = back.Image;
            exit.Image = back.Image;
            back.ImageEntity.Enable = false;
            reset.ImageEntity.Enable = false;
            title.ImageEntity.Enable = false;
            exit.ImageEntity.Enable = false;
            Image = ImageManage.GetSImage("window.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadUp))
                    Index--;
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.DPadDown))
                    Index++;
                if (IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Start) || IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.A))
                    ToEnter();
            }
            base.Update(gameTime);
        }

        private void ToEnter()
        {
            buts[index].OnClick(null, null);
        }

        private void Back(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset(object sender, EventArgs e)
        {
            GameRun.Instance.scenes["play"].Initialize();
        }

        private void Title(object sender, EventArgs e)
        {
            var sc = GameRun.Instance.scenes;
            sc["play"].IsRun = false;
            sc["play"].sounds["bgm"].Stop();
            sc["title"].IsRun = true;
            sc["title"].sounds["bgm"].Play();
            ((PlayScene)sc["play"]).NowStage = 0;
            sc["play"].Initialize();
        }

        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}
