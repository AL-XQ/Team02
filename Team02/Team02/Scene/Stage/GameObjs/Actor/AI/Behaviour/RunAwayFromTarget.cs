using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using InfinityGame;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class RunAwayFromTarget : BehaviourBase
    {
        private float speed;
        private D_Void _Action;

        public RunAwayFromTarget(float speed) : base()
        {
            this.speed = speed;
        }

        public RunAwayFromTarget(RunAwayFromTarget sample) : base(sample)
        {
            speed = sample.speed;
        }

        protected override void CheckGraChanger()
        {
            if (User.GraChanger == null)
            {
                _Action = RunAway;
            }
            else
            {
                _Action = null;
            }
            base.CheckGraChanger();
        }

        private void RunAway()
        {
            var ve = new Vector2(-speed, 0);
            ve = User.GetVeOnGra(ve);
            var check = User.Coordinate + ve;
            var checkL = (check - Target.Coordinate).LengthSquared() - (User.Coordinate - Target.Coordinate).LengthSquared();
            if (checkL < 0)
            {
                ve = -ve;
            }
            User.Forces["aimove"] = ve;
        }

        public override void Action()
        {
            _Action?.Invoke();
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
