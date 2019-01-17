using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Team02.Scene.Stage.GameObjs.Actor;
using InfinityGame.Device;

using InfinityGame.Element;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage
{
    public class BossStage1 : BossStage
    {
        public BossStage1(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            Boss = new BossPanel(this);
            Boss.Coordinate = new Vector2(12 * 64, 3 * 64);
            Boss.Hp = 2;
            Boss.Size = new Size(10 * 64, 11 * 64);
            Boss.Image = ImageManage.GetSImage("0_1.png");
            for (int i = 0; i < 2; i++)
            {
                Boss.Hits.Add(new BossHit(this, Boss));
                Boss.Hits[i].Size = new Size(64, 64);
            }
            Boss.Hits[0].Coordinate = new Vector2(17 * 64, 5 * 64);
            Boss.Hits[1].Coordinate = new Vector2(15 * 64, 8 * 64);
            Boss.Hits[0].Create();
            Boss.Hits[1].Create();
        }

        public override void PreLoadContent()
        {
            SpawnPoint[0] = new Vector2(64, 64);
            SpawnPoint[1] = new Vector2(10 * 64, 5 * 64);
            base.PreLoadContent();
        }
    }
}
