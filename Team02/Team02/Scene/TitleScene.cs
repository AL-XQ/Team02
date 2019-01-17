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

        public TitleScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {
        }

        public override void Initialize()
        {
            Refract = 1.0f;
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            DIYMouse.SetCursor(Cursors.normal);
            mainMenu = new MainMenu(this);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("title.png");
            sounds["bgm"] = SoundManage.GetSound("Title.wav");
            sounds["bgm"].SetSELoopPlay(true);
            sounds["bgm"].Play();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
