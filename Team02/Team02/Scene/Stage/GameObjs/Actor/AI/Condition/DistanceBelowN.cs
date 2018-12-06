using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Condition
{
    class DistanceBelowN : ConditionBase
    {
        private float minDistance;

        public DistanceBelowN(float minDistance)
        {
            this.minDistance = minDistance;
        }

        public override bool Check()
        {
            return Vector2.Distance(Target.Coordinate, User.Coordinate) < minDistance;
        }
    }
}
