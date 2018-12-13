using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class Fly : BehaviourBase
    {
        public Fly() : base()
        {

        }

        public Fly(Fly sample) : base(sample)
        {

        }

        public override void Action()
        {
            User.Forces["fly"] = -User.Gra;
        }

        public override bool IsRunning()
        {
            return false;
        }

        public override BehaviourBase Copy()
        {
            return new Fly(this);
        }
    }
}
