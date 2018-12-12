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
using InfinityGame.Device.MouseManage;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene
{
    public class ExplosionAreaUI : Label
    {
        private PlayScene playScene;

        public ExplosionAreaUI(BaseDisplay parent) : base(parent)
        {
            color = Color.Transparent;
            playScene = (PlayScene)parent;
            visible = false;
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("BurstSize.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Show(Point center)
        {
            size = image.Size;
            Point loc = center - (size / 2).ToPoint();
            Location = loc;
            visible = true;
        }

        public void NotShow()
        {
            visible = false;
        }
    }
}
