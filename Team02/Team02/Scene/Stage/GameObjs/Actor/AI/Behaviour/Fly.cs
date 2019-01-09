using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

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
            if (User.GraChanger == null)
            {
                User.Forces["fly"] = -User.Gra;
            }
        }

        public override bool IsRunning()
        {
            return false;
        }

        public override BehaviourBase Copy()
        {
            return new Fly(this);
        }

        public override void OnExit()
        {
            User.Speed = Vector2.Zero;
        }
    }
}
