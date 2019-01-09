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
        private float speed;

        public RunAwayFromTarget(float speed) : base()
        {
            this.speed = speed;
        }

        public RunAwayFromTarget(RunAwayFromTarget sample) : base(sample)
        {
            speed = sample.speed;
        }

        public override void Action()
        {
            var ve = new Vector2(-speed, 0);
            ve = User.GetVeOnGra(ve);
            var check = User.Coordinate + ve;
            var checkL = (check - Target.Coordinate).LengthSquared() - (User.Coordinate - Target.Coordinate).LengthSquared();
            if(checkL < 0)
            {
                ve = -ve;
            }
            User.Forces["aimove"] = ve;
        }

        public override BehaviourBase Copy()
        {
            return new RunAwayFromTarget(this);
        }

        public override bool IsRunning()
        {
            return false;
        }

        public override void OnExit()
        {
            User.Speed = Vector2.Zero;
        }
    }
}
