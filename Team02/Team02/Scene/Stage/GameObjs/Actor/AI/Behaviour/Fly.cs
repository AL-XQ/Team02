using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour
{
    public class Fly : BehaviourBase
    {
        public override void Action()
        {
            User.Forces["fly"] = new Microsoft.Xna.Framework.Vector2(0, -User.Gra.Y);
            //ここはGra.YではなくGraそのままに設定すべき
            //コメント：謝
        }

        public override bool IsRunning()
        {
            return false;
        }
    }
}
