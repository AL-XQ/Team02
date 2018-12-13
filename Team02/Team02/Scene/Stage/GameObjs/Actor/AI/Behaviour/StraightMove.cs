using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class StraightMove : BehaviourBase
    {
        private Vector2 direction;

        public StraightMove() : base()
        {

        }

        public StraightMove(StraightMove sample) : base(sample)
        {
            direction = sample.direction;
        }

        public StraightMove(Vector2 direction)
        {
            this.direction = direction;
        }

        public override void Action()
        {
            User.Forces["aimove"] = direction;
        }

        public override BehaviourBase Copy()
        {
            return new StraightMove(this);
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
