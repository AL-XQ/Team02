﻿using System;
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
using Team02.Device;
namespace Team02.Scene.Stage
{
    public class Stage01 : Base_Stage
    {
        public Stage01(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            EndOfRightDown = new Vector2(10000, 10000);
        }

        public override void PreLoadContent()
        {
            Player.CameraCenter = IGConfig.screen.ToVector2() / 2;
            Map = "test";
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
