using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Trigger;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class BossHit : TriggerObj
    {
        private BossPanel boss;
        private int imNum = 1;
        private int fl = 0;
        private bool plus = true;
        public BossPanel Boss { get => boss; set => boss = value; }
        public BossHit(BaseDisplay aParent, BossPanel boss) : base(aParent)
        {
            this.boss = boss;
            DrawOrder = 0;
        }

        public override void PreLoadContent()
        {
            Refract = 0.9f;
            Size = new Size(64, 64);
            base.PreLoadContent();
        }

        protected override void OffSet()
        {
            RenderCoo_Offset = -size.ToVector2() * new Vector2(2f, 2f);
            RenderSize_Offset = size.ToVector2() * new Vector2(4f, 4f);
        }

        public override void Update(GameTime gameTime)
        {
            if (boss != null && boss.Isover)
                Kill();
            if (plus)
                fl++;
            else
                fl--;
            if (fl >= 60 || fl <= 0)
                plus = !plus;
            imNum = fl / 5 + 1;
            base.Update(gameTime);
        }

        protected override void SetImage()
        {
            ImageName = "aim.png";
        }

        public override void CalCollision(StageObj obj)
        {
            if (!Dealing && obj is Enemy e && !obj.Dealing)
            {
                e.CharaKill();
                Kill();
                boss.Hp--;
            }
            base.CalCollision(obj);
        }

        public override void Draw2(GameTime gameTime)
        {
            for (int i = 0; i < imNum; i++)
                base.Draw2(gameTime);
        }
    }
}
