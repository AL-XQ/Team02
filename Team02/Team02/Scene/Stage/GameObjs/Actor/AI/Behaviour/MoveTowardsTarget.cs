using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class MoveTowardsTarget : BehaviourBase
    {
        private float speed;

        public MoveTowardsTarget(float speed)
        {
            this.speed = speed;
        }

        public override void Action()
        {
            Vector2 direction = Vector2.Normalize(Target.Coordinate - User.Coordinate);
            User.Forces["aimove"] = direction * speed;
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
