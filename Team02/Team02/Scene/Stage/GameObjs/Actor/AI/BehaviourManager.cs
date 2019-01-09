using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

using InfinityGame;

namespace Team02.Scene.Stage.GameObjs.Actor.AI
{
    public class BehaviourManager
    {
        private Chara user;
        private Chara target;
        private D_Void _BehaUpdate;
        public Chara User { get => user; set => SetUser(value); }
        public Chara Target { get => target; set => SetTarget(value); }

        private List<string> priorityList = new List<string>();
        private string currentBehaviour;
        private Dictionary<string, BehaviourConditionPair> bcPairs = new Dictionary<string, BehaviourConditionPair>();

        public BehaviourManager()
        {

        }

        public BehaviourManager(BehaviourManager sample)
        {
            User = sample.user;
            Target = sample.target;
            priorityList = sample.priorityList.ToList();
            currentBehaviour = sample.currentBehaviour;
            foreach(var l in sample.bcPairs)
            {
                bcPairs[l.Key] = l.Value.Copy();
            }
        }

        private void SetUser(Chara value)
        {
            user = value;

            //登録されている行動全てにUserを再設定
            foreach (var bcPair in bcPairs.Values)
            {
                bcPair.SetUser(value);
            }
        }

        private void SetTarget(Chara value)
        {
            target = value;

            //登録されている行動全てにTargetを再設定
            foreach (var bcPair in bcPairs.Values)
            {
                bcPair.SetTarget(value);
            }

            if (target == null)
                _BehaUpdate = SearchTarget;
            else
                _BehaUpdate = BehaUpdate;
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
            bcPairs[behaviourName].AddBehaviour(behaviour);
        }

        public void AddBehaviour(string behaviourName, BehaviourBase[] behaviours)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            foreach (var behaviour in behaviours)
            {
                bcPairs[behaviourName].AddBehaviour(behaviour);
            }
        }

        public void AddCondition(string behaviourName, ConditionBase condition)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            bcPairs[behaviourName].AddCondition(condition);
        }

        public void AddCondition(string behaviourName, ConditionBase[] conditions)
        {
#if DEBUG
            Debug.Assert(bcPairs.ContainsKey(behaviourName), behaviourName + "は登録されていません。先にCreateBehaviourを呼んでください。");
#endif
            foreach (var condition in conditions)
            {
                bcPairs[behaviourName].AddCondition(condition);
            }
        }

        public void Update()
        {
            _BehaUpdate?.Invoke();
        }

        private void SearchTarget()
        {
            var tar = User.CharaManager.Hero;
            if (tar != null)
                Target = tar;
        }

        private void BehaUpdate()
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
                    bcPairs[currentBehaviour].OnExit();
                    currentBehaviour = name;
                }
            }
        }

        public BehaviourManager Copy()
        {
            return new BehaviourManager(this);
        }
    }
}
