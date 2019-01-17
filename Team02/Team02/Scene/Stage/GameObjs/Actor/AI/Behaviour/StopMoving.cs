using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class StopMoving : BehaviourBase
    {
        private bool flying;

        public StopMoving()
        {
            flying = false;
        }

        public StopMoving(bool flying)
        {
            this.flying = flying;
        }

        public StopMoving(StopMoving sample) : base(sample)
        {
            flying = sample.flying;
        }

        public override void Action()
        {
            if (User.Forces.ContainsKey("aimove"))
                User.Forces["aimove"] = Vector2.Zero;

            if (User.Forces.ContainsKey("fly") && flying == false)
                User.Forces["fly"] = Vector2.Zero;
        }

        public override BehaviourBase Copy()
        {
            return new StopMoving(this);
        }

        public override bool IsRunning()
        {
            return false;
        }

        public override void OnExit()
        {
            
        }
    }
}
