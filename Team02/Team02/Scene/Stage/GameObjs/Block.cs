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
using Team02.Scene.Stage.GameObjs.API;

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
            MovePriority = 5;
            CrimpGroup = "block";
        }

        public Block(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            IsCrimp = true;
            BeMove = false;
            MovePriority = 5;
            CrimpGroup = "block";
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara oc)
            {
                if (oc.Speed.LengthSquared() >= oc.DamageSpeed * oc.DamageSpeed)
                {
                    oc.Hp -= 50;
                }
            }
            if (obj is IForce f)
            {
                DisCharaSpeed(f);
                if (!f.IsStrut && CheckIForceOn(f))
                {
                    FitIForce(f);
                    f.Strut();
                }
            }
            base.CalCollision(obj);
        }

        protected virtual void FitIForce(IForce f)
        {
            if (f is Chara c && !c.Rotating && (!c.LastIsStrut || c.ObjMemory["block"] != this))
            {
                var newGra = GetEscVe(c);
                var gv = c.Gra;
                gv.Normalize();
                float dot = Vector2.Dot(c.Speed, gv);
                Vector2 dg = gv * dot;//重力方向の速度
                c.Speed -= dg;
                c.Gra = newGra;
                c.ObjMemory["block"] = this;
                c.CheckLastIsStrut = false;
            }
        }

        protected virtual void DisCharaSpeed(IForce c)
        {
            c.DisSpeeds["block"] = coeff;
        }

        public Vector2 GetEscVe(Chara c)
        {
            ISpace check = c.ISpace.Copy();
            check.Location += c.Gra;
            if (ISpace is RectangleF rect)
            {
                var index = rect.GetCenterIntersectLine(check);
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
    }
}