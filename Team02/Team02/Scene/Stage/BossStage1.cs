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
            StageTime = 30;
        }

        public override void Initialize()
        {
            base.Initialize();
            Boss = new BossPanel(this);
            Boss.Coordinate = new Vector2(12 * 64, 3 * 64);
            Boss.Size = new Size(10 * 64, 11 * 64);
            Boss.Image = ImageManage.GetSImage("boss");
            Boss.CreateHitSpace(3);
        }

        public override void PreLoadContent()
        {
            SpawnPoint[0] = new Vector2(64, 64);
            SpawnPoint[1] = new Vector2(10 * 64, 5 * 64);
            base.PreLoadContent();
        }
    }
}
