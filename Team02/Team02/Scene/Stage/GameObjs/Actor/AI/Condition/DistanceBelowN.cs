﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Condition
{
    public class DistanceBelowN : ConditionBase
    {
        private float minDistance;

        public DistanceBelowN() : base()
        {

        }

        public DistanceBelowN(DistanceBelowN sample) : base(sample)
        {
            minDistance = sample.minDistance;
        }

        public DistanceBelowN(float minDistance)
        {
            this.minDistance = minDistance;
        }

        public override bool Check()
        {
            return Vector2.DistanceSquared(Target.Coordinate, User.Coordinate) < minDistance * minDistance;
        }

        public override ConditionBase Copy()
        {
            return new DistanceBelowN(this);
        }
    }
}
