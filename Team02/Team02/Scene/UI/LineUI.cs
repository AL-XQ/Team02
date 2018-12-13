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

namespace Team02.Scene.UI
{
    public class LineUI : Label
    {
        private PlayScene playScene;
        private Point playerPosition;
        private Point mousePosition;
        private float rotation;
        private Texture2D point;

        public LineUI(BaseDisplay parent) : base(parent)
        {
            //Color = Color.Transparent;
            playScene = (PlayScene)parent;
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            //Image = 
            point = new Texture2D(graphicsDevice, 1, 1);
            point.SetData<Color>(new Color[] { Color.Blue });
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            playerPosition = playScene.GetDrawLocation(playScene.Player.Chara.ISpace.Center);
            mousePosition = playScene.GameRun.GameMouse.MouseState.Position;
            //var temp0 = playerPosition - mousePosition;
            //var temp1 = temp0.ToVector2().Length();
            size = new Size(400, 3);

            Vector2 direction = mousePosition.ToVector2() - playerPosition.ToVector2();
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            base.Update(gameTime);
        }

        public override void Draw2(GameTime gameTime)
        {
            spriteBatch.Draw(point, new Rectangle(playerPosition, Size.ToPoint()), new Rectangle(Point.Zero, new Point(1, 1)), imageColor, rotation, Vector2.Zero, SpriteEffects.None, 1f);
            //base.Draw2(gameTime);
        }
    }
}
