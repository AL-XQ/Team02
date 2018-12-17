using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class Jump : BehaviourBase
    {
        private float jumpForce;

        public Jump() : base()
        {

        }

        public Jump(Jump sample) : base(sample)
        {
            jumpForce = sample.jumpForce;
        }
        public Jump(float jumpForce)
        {
            this.jumpForce = jumpForce;
        }

        public override void Action()
        {
            if (User.IsStrut)
            {
                User.Jump(jumpForce);
                return;
            }
        }

        public override BehaviourBase Copy()
        {
            return new Jump(this);
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
