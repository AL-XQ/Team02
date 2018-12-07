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
                Line clink = new Line(c.ISpace.Center, ISpace.Center, ISpace.Center);
                Vector2 check_I = Vector2.Zero;
                for (int i = 0; i < 4; i++)
                {
                    var s = (RectangleF)ISpace;
                    bool ans;
                    check_I = s.GetLine(i).Intersect(clink, out ans);
                    if (ans)
                        break;
                }
                Vector2 disve = check_I - c.ISpace.Center;
                Line lg = new Line(Vector2.Zero, c.Gra, VectorTools.Vertical(c.Gra));
                Vector2Side check = lg.PointAtY(disve);
                if (check == Vector2Side.Y_Plus)
                    return false;
                return true;
            }
            return false;
        }
    }
}