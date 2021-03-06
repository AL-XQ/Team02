﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using InfinityGame.Element;
using InfinityGame.Device;

using Microsoft.Xna.Framework;

namespace Team02.Scene.UI
{
    public class GameOver : Panel
    {
        private AnimeButton ok;
        private PlayScene playScene;
        private int fl = 0;
        public AnimeButton Ok { get => ok; }

        public GameOver(BaseDisplay aParent) : base(aParent)
        {
            playScene = (PlayScene)parent;
            BackColor = Color.Transparent;
        }

        public override void Initialize()
        {
            fl = 0;
            refract = 0;
            visible = false;
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            Size = parent.Size;
            ok = new AnimeButton(this);
            ok.Size = new Size(360, 60);
            ok.Location = new Point((size.Width - ok.Size.Width) / 2, size.Height - ok.Size.Height - 20);
            ok.Text = GetText("ok");
            ok.BDText.ForeColor = System.Drawing.Color.White;
            refract = 0.6f;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("FAIL.png");
            ok.Image = ImageManage.GetSImage("button");
            ok.ImageEntity.Enable = false;
            ok.Click += OK_Click;
            base.LoadContent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            playScene.BackMenu.Visible = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (visible && fl <= 60)
            {
                fl++;
                Refract = (fl / 1f + 1) / 61f;
            }
            base.Update(gameTime);
        }
    }
}
