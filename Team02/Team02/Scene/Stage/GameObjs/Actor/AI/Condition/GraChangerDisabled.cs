using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Condition
{
    class GraChangerDisabled : ConditionBase
    {
        public GraChangerDisabled(GraChangerDisabled sample) : base(sample)
        {

        }

        public override bool Check()
        {
            return User.GraChanger != null;
        }

        public override ConditionBase Copy()
        {
            return new GraChangerDisabled(this);
        }
    }
}
