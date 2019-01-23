using System;
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

        public AnimeButton Ok { get => ok; }

        public GameOver(BaseDisplay aParent) : base(aParent)
        {
            playScene = (PlayScene)parent;
        }

        public override void Initialize()
        {
            visible = false;
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            Size = parent.Size / 2;
            Location = ((parent.Size - size) / 2).ToPoint();
            ok = new AnimeButton(this);
            ok.Size = new Size(360, 60);
            ok.Location = new Point((size.Width - ok.Size.Width) / 2, size.Height - ok.Size.Height - 20);
            ok.Text = GetText("ok");
            refract = 0.6f;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("FAIL.png");
            ok.Image = ImageManage.GetSImage("button02");
            ok.Click += OK_Click;
            base.LoadContent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            playScene.BackMenu.Visible = true;
        }
    }
}
