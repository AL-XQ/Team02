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
                if (c.Speed.LengthSquared() >= 361 && c is Enemy)
                {
                    c.Hp -= 50;
                }
                c.DisSpeed(coeff);
                if (!c.IsStrut && CheckCharaOn(c))
                {
                    //テスト機能：キャラの重力をブロックにフィットする
                    var newGra = GetEscVe(c);
                    var gv = c.Gra;
                    c.Forces["strut"] = -gv;
                    gv.Normalize();
                    float dot = Vector2.Dot(c.Speed, gv);
                    Vector2 dg = gv * dot;//重力方向の速度
                    c.Speed -= dg;
                    c.Gra = newGra;
                    //テスト機能：キャラの重力をブロックにフィットする
                    c.Strut();
                }
            }
            base.CalCollision(obj);
        }

        public Vector2 GetEscVe(Chara c)
        {
            ISpace check = c.ISpace.Copy();
            check.Location += c.Gra;
            if (ISpace is RectangleF rect)
            {
                var index = rect.GetFristIntersectLine(check);
                if (index > -1)
                {
                    var escVe = rect.GetEscVe_Line(index);
                    escVe.Normalize();
                    escVe *= -c.Gra.Length();
                    return escVe;
                }
            }
            return Vector2.Zero;
        }

        public bool CheckCharaOn(Chara c)
        {
            if (c.Gra != Vector2.Zero)
            {
                ISpace check = c.ISpace.Copy();
                check.Location += c.Gra;
                if (ISpace.Intersects(check))
                {
                    var esc = ISpace.Escape(check);
                    if (esc != Vector2.Zero)
                        return true;
                }
            }
            return false;
        }
    }
}