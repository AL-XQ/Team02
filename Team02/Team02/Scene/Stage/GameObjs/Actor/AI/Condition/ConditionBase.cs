using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Condition
{
    public abstract class ConditionBase
    {
        private Chara user;
        public Chara User { get => user; set => user = value; }

        private Chara target;
        public Chara Target { get => target; set => target = value; }

        public ConditionBase() { }

        public ConditionBase(ConditionBase sample)
        {
            User = sample.user;
            Target = sample.target;
        }

        /// <summary>
        /// 条件判定の処理
        /// </summary>
        /// <returns></returns>
        public abstract bool Check();

        public abstract ConditionBase Copy();
    }
}
