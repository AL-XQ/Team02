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
            User.DisJump();
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
