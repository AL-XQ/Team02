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
        public StopMoving()
        {
        }

        public override void Action()
        {
            if (User.Forces.ContainsKey("aimove"))
                User.Forces["aimove"] = Vector2.Zero;

            if (User.Forces.ContainsKey("fly"))
                User.Forces["fly"] = Vector2.Zero;
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
