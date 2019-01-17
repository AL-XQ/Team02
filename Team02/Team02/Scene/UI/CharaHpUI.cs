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
    public class CharaHpUI : ObjUI
    {
        private Chara target;
        private SImage frontUI;
        private Size frontSize;

        public Chara Target { get => target; set => target = value; }

        public CharaHpUI(BaseDisplay parent) : base(parent)
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
            Size = new Size(image.Size.Width, image.Size.Height / 2);
            frontUI = ImageManage.GetSImage("HeroHp.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (target != null)
            {
                Coordinate = target.ISpace.Center - new Vector2(image.Size.Width / 2, target.Size.Height + 5);
                frontSize = new Size(target.Hp / (float)target.Maxhp * image.Size.Width, image.Size.Height / 2);
            }
            base.Update(gameTime);
        }

        

        public override void Draw2(GameTime gameTime)
        {
            base.Draw2(gameTime);
            Vector2 checkLocation = DrawLocation.ToVector2() + 2 * (RenderCoo_Offset * Stage.CameraScale);
            Vector2 checkSize = size.ToVector2() + RenderSize_Offset;
            if (checkLocation.X <= Stage.StageScene.Size.Width && checkLocation.Y <= Stage.StageScene.Size.Height)
            {
                if (checkLocation.X >= -checkSize.X * Stage.CameraScale && checkLocation.Y >= -checkSize.Y * Stage.CameraScale)
                {
                    Rectangle renderR = RenderRect;
                    if (renderR == default(Rectangle))
                        renderR = new Rectangle(Point.Zero, image.Size.ToPoint());
                    spriteBatch.Draw(frontUI.ImageT[iTIndex], new Rectangle(DrawLocation/* + (renderCoo_Offset * stage.CameraScale).ToPoint()*/, ((frontSize.ToVector2() + RenderSize_Offset) * Stage.CameraScale).ToPoint()), renderR, Color * refract, Rotation, ((Origin - RenderCoo_Offset) / (Size.ToVector2() + RenderSize_Offset)) * image.Size.ToVector2(), SpriteEffects.None, 1f);
                }
            }
        }
    }
}
