using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using InfinityGame.Device;
using InfinityGame.Element;
using InfinityGame.GameGraphics;

using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene.Stage
{
    public class TutorialStage : Base_Stage
    {
        public TutorialStage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {

        }

        public override void Initialize()
        {
            base.Initialize();

            SImage arrow = ImageManage.GetSImage("arrow.png");

            //重力操作の説明
            new ObjUI(this)
            {
                Coordinate = new Vector2(3350, 1300),
                Size = new Size(256, 64) * 3,
                Rotation = (float)(-10 * Math.PI / 180),
                Image = arrow,
            };

            //壁のぼりの説明

            new ObjUI(this)
            {
                Coordinate = new Vector2(5043, 1472),
                Size = new Size(256, 64),
                Image = arrow,
            };

            new ObjUI(this)
            {
                Coordinate = new Vector2(5400, 1500),
                Size = new Size(256, 64),
                Rotation = (float)(-90 * Math.PI / 180),
                Image = arrow,
            };

            new ObjUI(this)
            {
                Coordinate = new Vector2(5500, 1300),
                Size = new Size(192, 128),
                Image = ImageManage.GetSImage("DKey.png"),
            };

            //天井歩行の説明

            new ObjUI(this)
            {
                Coordinate = new Vector2(5734, 250),
                Size = new Size(256, 64),
                Rotation = (float)(-90 * Math.PI / 180),
                Image = arrow,
            };

            new ObjUI(this)
            {
                Coordinate = new Vector2(6000, 75),
                Size = new Size(256, 64),
                Image = arrow,
            };

            new ObjUI(this)
            {
                Coordinate = new Vector2(5900, 60),
                Size = new Size(192, 128),
                Image = ImageManage.GetSImage("AKey.png"),
            };
        }
    }
}
