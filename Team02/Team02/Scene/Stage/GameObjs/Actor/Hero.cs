﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Hero : Chara
    {
        public Hero(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Hero = this;
        }

        public override void LoadContent()
        {

            image = ImageManage.GetSImage("Player_Test.png");
            base.LoadContent();
        }
    }
}
