using InfinityGame;
using InfinityGame.Device;
using InfinityGame.Element;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02
{
    public enum Cursors
    {
        normal,
    }
    public static class DIYMouse
    {
        public static Color color = Color.White;
        private static SImage cursor;
        private static Point location = Point.Zero;
        private static Size size;
        public static void SetCursor(Cursors cursors)
        {
            cursor = ImageManage.GetSImage($"cursor_{cursors.ToString()}.png");
            size = cursor.Size;
        }
        public static void Update()
        {
            location = GameRun.Instance.GameMouse.MouseState.Position;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (cursor != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(cursor.ImageT[0], location.ToVector2() - (size / 2).ToVector2(), color);
                spriteBatch.End();
            }
        }
    }
}
