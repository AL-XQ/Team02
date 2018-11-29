﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    class Block : GameObj
    {
        public Block(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public override void PreLoadContent()
        {

            IsCrimp = true;
            RenderRect = new Rectangle(new Point(32, 32), new Point(64, 64));
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("Block_Test.png");
            base.LoadContent();
            
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara chara)
            {
                chara.ClearGraSpeed();
            }
            base.CalCollision(obj);
        }
    }
}