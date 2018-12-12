﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class RunAwayFromTarget : BehaviourBase
    {
        private float speed;

        public RunAwayFromTarget(float speed)
        {
            this.speed = speed;
        }

        public override void Action()
        {
            if (User.Coordinate.X < Target.Coordinate.X)
            {
                User.Forces["aimove"] = new Vector2(-1, 0) * speed;
            }
            else
            {
                User.Forces["aimove"] = new Vector2(1, 0) * speed;
            }
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
