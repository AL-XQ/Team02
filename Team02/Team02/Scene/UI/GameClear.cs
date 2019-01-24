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
    public class GameClear : Panel
    {
        private AnimeButton ok;
        private PlayScene playScene;
        private int imNum = 1;
        private int fl = 0;

        public AnimeButton Ok { get => ok; }

        public GameClear(BaseDisplay aParent) : base(aParent)
        {
            playScene = (PlayScene)parent;
            BackColor = Color.Transparent;
        }

        public override void Initialize()
        {
            fl = 0;
            imNum = 1;
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
            ok.ImageEntity.Enable = false;
            refract = 0.6f;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("CLEAR.png");
            ok.Image = ImageManage.GetSImage("button");
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
                imNum = fl / 10 + 1;
            }
            base.Update(gameTime);
        }

        public override void Draw1(GameTime gameTime)
        {
            for (int i = 0; i < imNum; i++)
                base.Draw1(gameTime);
        }
    }
}
