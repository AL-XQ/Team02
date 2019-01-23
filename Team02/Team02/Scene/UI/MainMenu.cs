using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.Device;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Team02.Scene.UI
{
    public class MainMenu : UIWindow
    {
        private AnimeButton start;
        private AnimeButton credit;
        private AnimeButton exit;
        private List<AnimeButton> buts = new List<AnimeButton>();
        private int index = 0;

        private bool bstart = false;

        private int Index { get => index; set => SetIndex(value); }
        public MainMenu(BaseDisplay parent) : base(parent)
        {
            canMove = false;
            canClose = false;
            BorderOn = false;
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
            bstart = false;
            Index = 0;
            base.Initialize();
        }

        private void RegistEvent()
        {
            start.Click += Start;
            exit.Click += Exit;
            credit.Click += Cdt;
        }

        public override void PreLoadContent()
        {
            Size = new Size(parent.Size.Width * 2 / 7, parent.Size.Height / 3);
            Location = new Point(0, parent.Size.Height - Size.Height);
            start = new AnimeButton(graphicsDevice, this);
            buts.Add(start);
            credit = new AnimeButton(graphicsDevice, this);
            buts.Add(credit);
            exit = new AnimeButton(graphicsDevice, this);
            buts.Add(exit);

            start.Size = new Size(size.Width * 4 / 5, size.Height * 1 / 6);
            credit.Size = start.Size;
            exit.Size = start.Size;
            start.Location = new Point(size.Width / 2 - start.Size.Width / 2, 30);
            credit.Location = start.Location + new Point(0, start.Size.Height + 10);
            exit.Location = credit.Location + new Point(0, credit.Size.Height + 10);

            RegistEvent();
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            start.Text = GetText("Start");
            credit.Text = GetText("Credit");
            exit.Text = GetText("Exit");
            start.BDText.ForeColor = System.Drawing.Color.White;
            credit.BDText.ForeColor = System.Drawing.Color.White;
            exit.BDText.ForeColor = System.Drawing.Color.White;
            start.TextAlign = ContentAlignment.MiddleCenter;
            credit.TextAlign = ContentAlignment.MiddleCenter;
            exit.TextAlign = ContentAlignment.MiddleCenter;
            var im = ImageManage.GetSImage("button");
            start.Image = im;
            credit.Image = im;
            exit.Image = im;
            start.ImageEntity.Enable = false;
            credit.ImageEntity.Enable = false;
            exit.ImageEntity.Enable = false;
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
                if (bstart)
                {
                    var sc = GameRun.Instance.scenes;
                    if (sc["title"].Refract > 0)
                    {
                        sc["title"].Refract *= 0.9f;
                        if (sc["title"].Refract < 0.05f)
                            sc["title"].Refract = 0;

                    }
                    else if (sc["title"].Refract <= 0)
                    {
                        sc["title"].IsRun = false;
                        sc["title"].sounds["bgm"].Stop();
                        sc["play"].IsRun = true;
                        sc["play"].sounds["bgm"].Play();
                        parent.Initialize();
                    }
                }
            }
            base.Update(gameTime);
        }

        private void ToEnter()
        {
            buts[index].OnClick(null, null);
        }

        private void Start(object sender, EventArgs e)
        {
            if (bstart)
                return;
            bstart = true;
        }

        private void Cdt(object sender, EventArgs e)
        {
            //((TitleScene)parent).Cridit.Visible = !((TitleScene)parent).Cridit.Visible;
        }

        private void Exit(object sender, EventArgs e)
        {
            Program.Exit();
        }

    }
}
