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
        private Block b0;
        private Block b2;
        private Block fl;
        private Block tp;
        public Stage01(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            EndOfRightDown = new Vector2(10000, 10000);
        }

        public override void PreLoadContent()
        {
            Player.Chara = new Hero(this, "hero");
            stageObjs["hero"].Coordinate = new Vector2(0, 200);
            stageObjs["hero"].Size = new Size(64, 64);
            b0 = new Block(this, "block");
            stageObjs["block"].Coordinate = new Vector2(300, 400);
            b2 = new Block(this, "block2");
            stageObjs["block2"].Coordinate = new Vector2(1000, 400);
            fl = new Block(this, "floor");
            stageObjs["floor"].Coordinate = new Vector2(0, 900 - 64);
            tp = new Block(this, "top");
            stageObjs["top"].Coordinate = new Vector2(0, 0);
            Player.CameraCenter = IGConfig.screen.ToVector2() / 2;

            new Enemy(this, "enemy");
            stageObjs["enemy"].Coordinate = new Vector2(1000, 0);
            stageObjs["enemy"].Size = new Size(64, 64);

            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            b0.UnitedSize = new Size(4, 3);
            b0.Rotation = 0.5f;
            b2.UnitedSize = new Size(2, 3);
            b2.Rotation = 0.5f;
            fl.UnitedSize = new Size(25, 1);
            tp.UnitedSize = new Size(25, 1);
        }
    }
}
