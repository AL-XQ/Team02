using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Trigger;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class BossHit : TriggerObj
    {
        private BossPanel boss;
        public BossPanel Boss { get => boss; set => boss = value; }
        public BossHit(BaseDisplay aParent, BossPanel boss) : base(aParent)
        {
            this.boss = boss;
            DrawOrder = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (boss == null || boss.Isover)
                Kill();
            base.Update(gameTime);
        }

        protected override void SetImage()
        {
            ImageName = "EnemyRateFront.png";
        }

        public override void CalCollision(StageObj obj)
        {
            if (!Dealing && obj is Enemy && !obj.Dealing)
            {
                obj.Kill();
                Kill();
                boss.Hp--;
            }
            base.CalCollision(obj);
        }
    }
}
