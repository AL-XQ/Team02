﻿using System;
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
        private Panel pa;
        private int enemyCnt;
        private int maxEnemyCnt;

        public int EnemyCnt { get => enemyCnt; set => enemyCnt = value; }
        public int MaxEnemyCnt { get => maxEnemyCnt; set => maxEnemyCnt = value; }

        public EnemyCountUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
            enemyCnt = 0;
            maxEnemyCnt = 0;
        }

        public override void PreLoadContent()
        {
            pa = new Panel(this);
            pa.Location = Point.Zero;
            Location = Point.Zero;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("EnemyRateFront.png");
            pa.Image = ImageManage.GetSImage("EnemyRateBack.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw1(GameTime gameTime)
        {
            float rate = 1 - enemyCnt / maxEnemyCnt;
            spriteBatch.Draw(pa.Image.ImageT[iTIndex], pa.Location.ToVector2(), Color.White);
            spriteBatch.Draw(image.ImageT[iTIndex], Location.ToVector2(), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1, rate), SpriteEffects.None, 1.0f);
        }
    }
}
