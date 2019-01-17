using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Team02.Scene.Stage.GameObjs;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class BossPanel : ObjUI
    {
        private int hp;
        private bool isover = false;
        private List<BossHit> hits = new List<BossHit>();
        private RandomF rnd = new RandomF();

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

        public void CreateHitSpace(int num)
        {
            Hp = num;
            for (int i = 0; i < num; i++)
            {
                var hit = new BossHit(Stage, this);
                hit.Coordinate = new Vector2(rnd.NextFloat(Coordinate.X, Coordinate.X + size.Width - 64), rnd.NextFloat(Coordinate.Y, Coordinate.Y + size.Height - 64));
                hits.Add(hit);
                hit.Create();
            }
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero h)
                h.CharaKill();
            base.CalCollision(obj);
        }
    }
}
