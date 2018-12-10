using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class Fly : BehaviourBase
    {
        public override void Action()
        {
            User.Forces["fly"] = new Microsoft.Xna.Framework.Vector2(0, -User.Gra.Y);
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
