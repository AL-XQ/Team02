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


namespace Team02.Scene.UI
{
    public class HeroHpUI : Panel
    {
        private PlayScene playScene;
        private Panel backPa;
        private Vector2 position;

        public HeroHpUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            backPa = new Panel(this);
            backPa.Visible = false;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("HeroHp.png");
            size = new Size(image.Size.Width, image.Size.Height);
            backPa.Image = ImageManage.GetSImage("EnemyHp.png");
            backPa.Size = new Size(image.Size.Width, image.Size.Height);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var hero = ((Base_Stage)playScene.ShowStage).CharaManager.Hero;
            if (hero != null)
                position = hero.Coordinate - new Vector2(20, size.Height);
            base.Update(gameTime);
        }

        public override void Draw1(GameTime gameTime)
        {
            float rate = (float)((Base_Stage)playScene.ShowStage).CharaManager.Hero.Hp / ((Base_Stage)playScene.ShowStage).CharaManager.Hero.Maxhp;
            spriteBatch.Draw(backPa.Image.ImageT[iTIndex], playScene.GetDrawLocation(position).ToVector2(), null, Color.White, 0.0f, Vector2.Zero, new Vector2(1, 0.5f), SpriteEffects.None, 1.0f);
            spriteBatch.Draw(image.ImageT[iTIndex], playScene.GetDrawLocation(position).ToVector2(), null, Color.White, 0.0f, Vector2.Zero, new Vector2(rate, 0.5f), SpriteEffects.None, 1.0f);
        }
    }
}
