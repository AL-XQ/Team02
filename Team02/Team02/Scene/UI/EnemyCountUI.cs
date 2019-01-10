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
    public class EnemyCountUI :Panel
    {
        private PlayScene playScene;
        private Panel frontPa;
        private Label numberLa;
        private int enemyCnt;
        private int maxEnemyCnt;
        private bool isClear;

        public int EnemyCnt { get => enemyCnt; set => enemyCnt = value; }
        public int MaxEnemyCnt { get => maxEnemyCnt; set => maxEnemyCnt = value; }
        public bool IsClear { get => isClear; set => isClear = value; }

        public EnemyCountUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
            isClear = false;
        }

        public override void PreLoadContent()
        {
            Location = Point.Zero;
            frontPa = new Panel(this);
            frontPa.Location = Location;
            numberLa = new Label(this);
            numberLa.BDText.ForeColor = System.Drawing.Color.Red;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("EnemyCountFront.png");
            Size = new Size(image.Size.Width, image.Size.Height);
            frontPa.Image = ImageManage.GetSImage("EnemyCountBack.png");
            frontPa.Size = new Size(frontPa.Image.Size.Width, frontPa.Image.Size.Height);
            numberLa.Location = new Point(0, Size.Height);
            frontPa.Visible = false;
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            numberLa.Text = enemyCnt + "/" + maxEnemyCnt;
            if (enemyCnt == 0)
            {
                isClear = true;
            }
            base.Update(gameTime);
        }

        public override void Draw1(GameTime gameTime)
        {
            float rate =(1.0f - (float)enemyCnt / maxEnemyCnt) * (float)Math.PI / 2.0f;
            spriteBatch.Draw(Image.ImageT[iTIndex], Location.ToVector2(), Color.White);
            spriteBatch.Draw(frontPa.Image.ImageT[iTIndex], frontPa.Location.ToVector2(), null, Color.White, -rate, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 1.0f);
        }
    }
}
