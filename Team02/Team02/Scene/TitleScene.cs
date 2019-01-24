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
using InfinityGame.Element;

namespace Team02.Scene
{
    public class TitleScene : BaseScene
    {
        private MainMenu mainMenu;
        private Credit credit;
        private SImage backim;
        private Vector2[] backimLoc = new Vector2[2];
        private Vector2 targetLoc = Vector2.Zero;
        private float backimSpeed = 3;
        public Credit Credit { get => credit; }

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
            credit = new Credit(this);
            backimLoc[0] = new Vector2(0, -size.Height);
            backimLoc[1] = Vector2.Zero;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("title.png");
            backim = ImageManage.GetSImage("title_bg.png");
            sounds["bgm"] = SoundManage.GetSound("Title.wav");
            sounds["bgm"].SetSELoopPlay(true);
            sounds["bgm"].Play();
            base.LoadContent();
        }

        private void AddTargetLoc(ref Vector2 loc, float speed)
        {
            var y = loc.Y + speed;
            if (y >= size.Height)
                y = 0;
            else if (y <= 0)
                y = size.Height;
            loc.Y = y;
            backimLoc[0].Y = loc.Y - size.Height;
            backimLoc[1].Y = loc.Y;
        }

        public override void Update(GameTime gameTime)
        {
            AddTargetLoc(ref targetLoc, backimSpeed);
            base.Update(gameTime);
        }

        public override void Draw2(GameTime gameTime)
        {
            spriteBatch.Draw(backim.ImageT[0], new Rectangle(backimLoc[0].ToPoint(), size.ToPoint()), color * refract);
            spriteBatch.Draw(backim.ImageT[0], new Rectangle(backimLoc[1].ToPoint(), size.ToPoint()), color * refract);
            base.Draw2(gameTime);
        }
    }
}
