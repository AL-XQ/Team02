using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

namespace Team02.Scene.Stage.GameObjs.Actor.AI
{
    public class BehaviourManager
    {
        private Chara user;
        private Chara target;
        public Chara Target { get; set; }

        private List<string> priorityList = new List<string>();
        private string currentBehaviour;
        private Dictionary<string, BehaviourConditionPair> bcPairs = new Dictionary<string, BehaviourConditionPair>();

        public BehaviourManager(Chara user, Chara target)
        {
            this.user = user;
            this.target = target;
        }

        public void CreateBehaviour(string behaviourName, int priority)
        {
#if DEBUG
            Debug.Assert(!bcPairs.ContainsKey(behaviourName), behaviourName + "は既に登録されています");
            Debug.Assert(priority > -1, "優先度は0以上の値で指定してください");
#endif
            if (currentBehaviour == null)
            {
                currentBehaviour = behaviourName;
            }
            priorityList.Insert(priority, behaviourName);
            bcPairs.Add(behaviourName, new BehaviourConditionPair());
        }

        public void AddBehaviour(string behaviourName, BehaviourBase behaviour)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            behaviour.User = user;
            behaviour.Target = target;
            bcPairs[behaviourName].AddBehaviour(behaviour);
        }

        public void AddBehaviour(string behaviourName, BehaviourBase[] behaviours)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            foreach(var behaviour in behaviours)
            {
                behaviour.User = user;
                behaviour.Target = target;
                bcPairs[behaviourName].AddBehaviour(behaviour);
            }
        }

        public void AddCondition(string behaviourName, ConditionBase condition)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            condition.User = user;
            condition.Target = target;
            bcPairs[behaviourName].AddCondition(condition);
        }

        public void AddCondition(string behaviourName, ConditionBase[] conditions)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            foreach (var condition in conditions)
            {
                condition.User = user;
                condition.Target = target;
                bcPairs[behaviourName].AddCondition(condition);
            }
        }

        public void Update()
        {
            if (currentBehaviour == null)
            {
                return;
            }

            if (bcPairs[currentBehaviour].CheckCondition() == false &&
                bcPairs[currentBehaviour].IsRunning() == false)
            {
                ReselectBehaviour();
            }

            bcPairs[currentBehaviour].Action();
        }

        public void ReselectBehaviour()
        {
            foreach (string name in priorityList)
            {
                if (bcPairs[name].CheckCondition())
                {
                    currentBehaviour = name;
                }
            }
        }
    }
}
