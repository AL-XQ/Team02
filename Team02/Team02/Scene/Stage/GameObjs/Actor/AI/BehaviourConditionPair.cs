using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

namespace Team02.Scene.Stage.GameObjs.Actor.AI
{
    public class BehaviourConditionPair
    {
        private List<BehaviourBase> behaviours = new List<BehaviourBase>();
        private List<ConditionBase> conditions = new List<ConditionBase>();

        public void AddBehaviour(BehaviourBase behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void AddCondition(ConditionBase condition)
        {
            conditions.Add(condition);
        }

        public void Action()
        {
            foreach(var behaviour in behaviours)
            {
                behaviour.Action();
            }
        }

        public bool CheckCondition()
        {
            foreach (ConditionBase condition in conditions)
            {
                if (condition.Check() == false)
                    return false;
            }

            return true;
        }
    }
}
