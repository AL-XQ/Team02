using InfinityGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public abstract class BehaviourBase
    {
        private Chara user;
        protected D_Void _Action;
        public Chara User { get => user; set => SetUser(value); }

        private Chara target;
        public Chara Target { get => target; set => target = value; }

        public BehaviourBase() { }

        public BehaviourBase(BehaviourBase sample)
        {
            User = sample.user;
            Target = sample.Target;
        }

        protected virtual void SetUser(Chara value)
        {
            if (user != null)
                user._GraChangerChanged -= CheckGraChanger;
            user = value;
            if (user != null)
                user._GraChangerChanged += CheckGraChanger;
        }

        protected virtual void CheckGraChanger()
        {
            
        }


        /// <summary>
        /// 行動が実行中かどうか返します
        /// </summary>
        /// <returns></returns>
        public abstract bool IsRunning();

        /// <summary>
        /// 行動(敵を動かす処理はここに書く)
        /// </summary>
        public virtual void Action()
        {
            _Action?.Invoke();
        }

        public abstract BehaviourBase Copy();

        public abstract void OnExit();
    }
}
