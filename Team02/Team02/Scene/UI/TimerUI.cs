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
    public class TimerUI : Panel
    {
        private PlayScene playScene;
        private Panel frontPa;
        private Label numberLa;
        private bool isTime;
        private float currentTime;
        private float limitTime;

        public float CurrentTime { get => currentTime; set => currentTime = value; }
        public float LimitTime { get => limitTime; set => limitTime = value; }
        public bool IsTime { get => isTime; set => isTime = value; }
        public TimerUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
        }

        public override void PreLoadContent()
        {
            frontPa = new Panel(this);
            numberLa = new Label(this);
            numberLa.BDText.ForeColor = System.Drawing.Color.Red;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("EnemyRateFront.png");
            Size = new Size(image.Size.Width, image.Size.Height);
            Location = new Point(playScene.Size.Width - Size.Width, 0);
            frontPa.Image = ImageManage.GetSImage("EnemyRateBack.png");
            frontPa.Size = new Size(frontPa.Image.Size.Width, frontPa.Image.Size.Height);
            frontPa.Location = Location;
            numberLa.Location = new Point(0, Size.Height);
            frontPa.Visible = false;
            SetTime(60);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            currentTime = Math.Max(currentTime - 1.0f, 0.0f);
            numberLa.Text = ((int)(currentTime / 60)).ToString();
            if (currentTime <= 0.0f)
            {
                isTime = true;
            }
            base.Update(gameTime);
        }

        public void SetTime(int time)
        {
            limitTime = time * 60f;
            currentTime = limitTime;
        }

        public override void Draw1(GameTime gameTime)
        {
            float rate = currentTime / limitTime;
            spriteBatch.Draw(Image.ImageT[iTIndex], Location.ToVector2(), Color.White);
            spriteBatch.Draw(frontPa.Image.ImageT[iTIndex], frontPa.Location.ToVector2(), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1, rate), SpriteEffects.None, 1.0f);
        }
    }
}
