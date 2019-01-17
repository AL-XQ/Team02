using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class BossPanel : ObjUI
    {
        private int hp;
        private bool isover = false;
        private List<BossHit> hits = new List<BossHit>();

        public int Hp { get => hp; set => SetHp(value); }
        public List<BossHit> Hits { get => hits; }
        public bool Isover { get => isover; }

        public BossPanel(BaseDisplay aParent) : base(aParent)
        {
            DrawOrder = 0;
        }

        public BossPanel(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            DrawOrder = 0;
        }

        private void SetHp(int value)
        {
            hp = value;
            if (hp <= 0)
                Over();
        }

        private void Over()
        {
            if (isover)
                return;
            Visible = false;//仮
            isover = true;
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero)
                obj.Kill();
            base.CalCollision(obj);
        }
    }
}
