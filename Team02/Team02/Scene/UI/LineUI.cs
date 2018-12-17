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
    public class LineUI : Panel
    {
        private PlayScene playScene;
        private Point playerPosition;
        private Point mousePosition;

        private float rotation;
        private string imageName;

        private bool isShoot = true;

        public bool IsShoot { get => isShoot; set => SetIsShoot(value); }

        public string ImageName { get => imageName; set => SetImageName(value); }

        public LineUI(BaseDisplay parent) : base(parent)
        {
            //Color = Color.Transparent;
            playScene = (PlayScene)parent;


        }

        private void SetImageName(string value)
        {
            imageName = value;
            if (ImageName != null)
            {
                image = ImageManage.GetSImage(imageName);
            }
        }

        private void SetIsShoot(bool value)
        {
            isShoot = value;
            if (isShoot)
            {
                ImageName = "lazer_test.png";
                Size = new Size(400, image.Size.Height);
                return;
            }
            ImageName = "arrow_test.png";
            Size = new Size(image.Size.Width * 3 / 4, image.Size.Height);
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            IsShoot = true;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            playerPosition = playScene.GetDrawLocation(playScene.Player.Chara.ISpace.Center);
            mousePosition = playScene.GameRun.GameMouse.MouseState.Position;
            var temp0 = playerPosition - mousePosition;
            var temp1 = temp0.ToVector2().Length();
            if (isShoot)
                Size = new Size(temp1, image.Size.Height);

            Vector2 direction = mousePosition.ToVector2() - playerPosition.ToVector2();
            rotation = (float)Math.Atan2(direction.Y, direction.X);

            base.Update(gameTime);
        }

        public override void Draw1(GameTime gameTime)
        {
            spriteBatch.Draw(image.ImageT[iTIndex], new Rectangle(playerPosition, Size.ToPoint()), new Rectangle(Point.Zero, Image.Size.ToPoint()), imageColor, rotation, new Vector2(0, image.Size.Height / 2), SpriteEffects.None, 1f);
        }
    }
}
