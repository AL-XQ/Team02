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
using Team02.Scene.Stage;
using Team02.Scene.Stage.GameObjs.Actor;


namespace Team02.Scene.UI
{
    public class EnemyHpUI : ObjUI
    {
        private Chara target;

        public Chara Target { get => target; set => target = value; }

        public EnemyHpUI(BaseDisplay parent) : base(parent)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("EnemyHp.png");
            Size = new Size(image.Size.Width, image.Size.Height);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (target != null)
            {
                Coordinate = target.ISpace.Center - new Vector2(image.Size.Width / 2, target.Size.Height + 5);
                Size = new Size(target.Hp / (float)target.Maxhp * image.Size.Width, image.Size.Height / 2);
            }
            base.Update(gameTime);
        }

        /*public override void Draw2(GameTime gameTime)
        {
            if (target != null)
            {
                float rate = target.Hp / target.Maxhp;
                spriteBatch.Draw(image.ImageT[iTIndex], Coordinate, null, Color.White, 0.0f, Vector2.Zero, new Vector2(rate, 0.5f), SpriteEffects.None, 1.0f);
            }
        }*/
    }
}
