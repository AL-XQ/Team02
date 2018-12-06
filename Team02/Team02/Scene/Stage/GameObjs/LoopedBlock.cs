using InfinityGame.Element;
using InfinityGame.GameGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class LoopedBlock : Block
    {
        public static readonly Size _UnitSize = new Size(64, 64);

        private Size unitedSize = new Size(1, 1);
        private RenderTarget2D tex;
        private Rectangle[,] texRects = new Rectangle[3, 3];

        public Size UnitedSize { get => unitedSize; set => SetUnitedSize(value); }
        public LoopedBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            tex = new RenderTarget2D(graphicsDevice, _UnitSize.Width, _UnitSize.Height);
        }

        private void SetUnitedSize(Size value)
        {
            unitedSize = value;
            Size = _UnitSize * unitedSize;
            CreateTex();
        }

        protected override void SetImageName(string value)
        {
            base.SetImageName(value);
            int w = image.Size.Width / 3;
            int h = image.Size.Height / 3;
            Size s = image.Size / 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    texRects[i, j] = new Rectangle(new Point(i * w, j * h), s.ToPoint());
                }
            }
        }

        private void CreateTex()
        {
            if (tex != null)
                tex.Dispose();
            tex = new RenderTarget2D(graphicsDevice, size.Width, size.Height);
            graphicsDevice.SetRenderTarget(tex);
            graphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin();
            int w = Size.Width / unitedSize.Width;
            int h = Size.Height / unitedSize.Height;
            Size s = Size / unitedSize;
            for (int i = 0; i < unitedSize.Width; i++)
            {
                for (int j = 0; j < unitedSize.Height; j++)
                {
                    int ti = 1, tj = 1;
                    if (i == 0)
                        ti = 0;
                    else if (i == unitedSize.Width - 1)
                        ti = 2;
                    if (j == 0)
                        tj = 0;
                    else if (j == unitedSize.Height - 1)
                        tj = 2;
                    spriteBatch.Draw(image.ImageT[iTIndex], new Rectangle(new Point(i * w, j * h), s.ToPoint()), texRects[ti, tj], Color.White);
                }
            }
            spriteBatch.End();
            graphicsDevice.SetRenderTarget(null);
        }

        public override void Draw2(GameTime gameTime)
        {
            if (tex != null)
            {
                Vector2 checkLocation = DrawLocation.ToVector2() + 2 * RenderCoo_Offset;
                Vector2 checkSize = size.ToVector2() + RenderSize_Offset;
                if (checkLocation.X <= Stage.StageScene.Size.Width && checkLocation.Y <= Stage.StageScene.Size.Height)
                {
                    if (checkLocation.X >= -checkSize.X * Stage.CameraScale && checkLocation.Y >= -checkSize.Y * Stage.CameraScale)
                    {
                        Rectangle renderR = RenderRect;
                        if (renderR == default(Rectangle))
                            renderR = new Rectangle(Point.Zero, Size.ToPoint());
                        spriteBatch.Draw(tex, new Rectangle(DrawLocation + RenderCoo_Offset.ToPoint(), ((Size.ToVector2() + RenderSize_Offset) * Stage.CameraScale).ToPoint()), renderR, Color * refract, Rotation, ((Origin - RenderCoo_Offset) / (Size.ToVector2() + RenderSize_Offset)) * Size.ToVector2(), SpriteEffects.None, 1f);
                    }
                }
            }
        }
    }
}
