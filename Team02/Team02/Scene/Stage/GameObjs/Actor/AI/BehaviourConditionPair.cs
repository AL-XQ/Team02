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

        public BehaviourConditionPair()
        {
            
        }

        public BehaviourConditionPair(BehaviourConditionPair sample)
        {
            foreach(var l in sample.behaviours)
            {
                behaviours.Add(l.Copy());
            }
            foreach(var l in sample.conditions)
            {
                conditions.Add(l.Copy());
            }
        }

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
            foreach (var behaviour in behaviours)
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

        public bool IsRunning()
        {
            foreach (var behaviour in behaviours)
            {
                if (behaviour.IsRunning() == true)
                    return true;
            }

            return false;
        }

        public void SetUser(Chara value)
        {
            behaviours.ForEach(b => b.User = value);
            conditions.ForEach(c => c.User = value);
        }

        public void SetTarget(Chara value)
        {
            behaviours.ForEach(b => b.Target = value);
            conditions.ForEach(c => c.Target = value);
        }

        public BehaviourConditionPair Copy()
        {
            return new BehaviourConditionPair(this);
        }

        public void OnExit()
        {
            behaviours.ForEach(b => b.OnExit());
        }
    }
}
