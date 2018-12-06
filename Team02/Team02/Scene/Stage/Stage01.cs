using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Def;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage
{
    public class Stage01 : Base_Stage
    {
        private LoopedBlock b0;
        public Stage01(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            EndOfRightDown = new Vector2(10000, 10000);
        }

        public override void PreLoadContent()
        {
            Player.Chara = new Hero(this, "hero");
            stageObjs["hero"].Coordinate = new Vector2(0, 200);
            stageObjs["hero"].Size = new Size(64, 64);
            b0 = new LoopedBlock(this, "block");
            stageObjs["block"].Coordinate = new Vector2(300, 400);
            new Block(this, "block2");
            stageObjs["block2"].Coordinate = new Vector2(1000, 400);
            stageObjs["block2"].Size = new Size(64 * 2, 64 * 4);
            stageObjs["block2"].Rotation = 0.5f;
            stageObjs["block2"].Origin = (stageObjs["block2"].Size / 2).ToVector2();
            new Block(this, "floor");
            stageObjs["floor"].Coordinate = new Vector2(0, 900 - 64);
            stageObjs["floor"].Size = new Size(1600, 64);
            new Block(this, "top");
            stageObjs["top"].Coordinate = new Vector2(0, 0);
            stageObjs["top"].Size = new Size(1600, 64);
            Player.CameraCenter = new Vector2(0, IGConfig.screen.Height / 2);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            b0.UnitedSize = new Size(4, 3);
            b0.Rotation = 0.5f;
        }
    }
}
