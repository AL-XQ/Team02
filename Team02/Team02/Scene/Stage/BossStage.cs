using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame;
using InfinityGame.Element;

using Team02.Scene.Stage.GameObjs.Actor.AI;

using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage
{
    public class BossStage : Base_Stage
    {
        private BossPanel boss;
        private int maxEnemy = 10;
        private RandomF rnd = new RandomF();
        private Vector2[] spawnPoint = new Vector2[2];

        public BossPanel Boss { get => boss; set => boss = value; }
        public Vector2[] SpawnPoint { get => spawnPoint; }

        public BossStage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {

        }

        public void SpawnEnemy()
        {
            var coo = new Vector2(rnd.NextFloat(SpawnPoint[0].X, SpawnPoint[1].X), rnd.NextFloat(SpawnPoint[0].Y, SpawnPoint[1].Y));
            var ai = AIPackage.GetAIByIndex(AIPackage.AIs.Count);
            var size = new Size(64, 64);
            CharaManager.CreateEnemy(coo, size, ai);
        }

        public override void Update(GameTime gameTime)
        {
            if (boss != null && !boss.Isover && rnd.Next(100) == 0 && CharaManager.Enemys.Count < maxEnemy)
            {
                SpawnEnemy();
            }
            base.Update(gameTime);
        }
    }
}
