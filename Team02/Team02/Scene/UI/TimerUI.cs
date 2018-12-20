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
        private Panel pa;
        private float currentTime;
        private float limitTime;

        public float CurrentTime { get => currentTime; set => currentTime = value; }
        public float LimitTime { get => limitTime; set => limitTime = value; }
        public TimerUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
        }

        public override void PreLoadContent()
        {
            pa = new Panel(this);
            pa.Location = new Point(200, 0);
            Location = new Point(200,0);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            pa.Image = ImageManage.GetSImage("EnemyRateBack.png");
            pa.Size = new Size(pa.Image.Size.Width, pa.Image.Size.Height);
            Image = ImageManage.GetSImage("EnemyRateFront.png");
            SetTime(60);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            currentTime = Math.Max(currentTime - 1.0f, 0.0f);
            base.Update(gameTime);
        }

        public void SetTime(int time)
        {
            limitTime = time * 60f;
            currentTime = limitTime;
        }

        public override void Draw1(GameTime gameTime)
        {
            float rate = 1 - currentTime / limitTime;
            //spriteBatch.Draw(pa.Image.ImageT[iTIndex], pa.Location.ToVector2(), Color.White);
            spriteBatch.Draw(image.ImageT[iTIndex], Location.ToVector2(), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1, rate), SpriteEffects.None, 1.0f);
        }
    }
}
