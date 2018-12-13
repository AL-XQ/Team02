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

        public MoveTowardsTarget() : base()
        {

        }

        public MoveTowardsTarget(MoveTowardsTarget sample) : base(sample)
        {
            speed = sample.speed;
        }

        public MoveTowardsTarget(float speed)
        {
            this.speed = speed;
        }

        public override void Action()
        {
            Vector2 check = Target.Coordinate - User.Coordinate;
            if (check.X != 0 && check.Y != 0)
            {
                Vector2 direction = Vector2.Normalize(check);
                User.Forces["aimove"] = direction * speed;
            }
        }

        public override BehaviourBase Copy()
        {
            return new MoveTowardsTarget(this);
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
