using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class RunAwayFromTarget : BehaviourBase
    {
        private float speedModfier;

        public RunAwayFromTarget(float speedModfier)
        {
            this.speedModfier = speedModfier;
        }

        public override void Action()
        {
            if (User.Coordinate.X < Target.Coordinate.X)
            {
                User.Forces["aimove"] = new Vector2(-1, 0) * speedModfier;
            }
            else
            {
                User.Forces["aimove"] = new Vector2(1, 0) * speedModfier;
            }
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
