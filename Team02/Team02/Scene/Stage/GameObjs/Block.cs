using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class Block : LoopedBlock
    {
        private float coeff = 0.05f;
        public float Coeff { get => coeff; set => coeff = value; }

        public Block(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
            BeMove = false;
            MovePriority = 10;
            CrimpGroup = "block";
        }

        public Block(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            IsCrimp = true;
            BeMove = false;
            MovePriority = 10;
            CrimpGroup = "block";
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara c)
            {
                if (c.Speed.Length() >= 20 && c is Enemy)//テスト用の為length
                {
                    c.Hp -= 50;
                }
                c.DisSpeed(coeff);
                if (CheckCharaOn(c))
                {
                    c.Strut();
                }
            }
            base.CalCollision(obj);
        }

        private bool CheckCharaOn(Chara c)
        {
            if (c.Gra.LengthSquared() != 0)
            {
                ISpace check = c.ISpace;
                check.Location += c.Gra;
                if (ISpace.Intersects(check) && ISpace.Escape(check).LengthSquared() > 0)
                    return true;
            }
            return false;
        }
    }
}