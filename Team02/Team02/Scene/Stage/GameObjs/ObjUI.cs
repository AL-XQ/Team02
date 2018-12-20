using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;

namespace Team02.Scene.Stage.GameObjs
{
    /// <summary>
    /// ステージオブジェクトとして扱われるUI
    /// </summary>
    public class ObjUI : GameObj
    {
        public ObjUI(BaseDisplay aParent) : base(aParent)
        {
            IsCrimp = false;
            CanCollision = false;
            EnableColl = false;
        }

        public ObjUI(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = false;
            CanCollision = false;
            EnableColl = false;
        }

        public override void CrimpPro_End()
        {
            //UIであるため処理させない
        }
    }
}
