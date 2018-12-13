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
        public Chara User { get => user; set => user = value; }

        private Chara target;
        public Chara Target { get => target; set => target = value; }

        public BehaviourBase() { }

        public BehaviourBase(BehaviourBase sample)
        {
            User = sample.user;
            Target = sample.Target;
        }

        /// <summary>
        /// 行動が実行中かどうか返します
        /// </summary>
        /// <returns></returns>
        public abstract bool IsRunning();

        /// <summary>
        /// 行動(敵を動かす処理はここに書く)
        /// </summary>
        public abstract void Action();

        public abstract BehaviourBase Copy();
    }
}
