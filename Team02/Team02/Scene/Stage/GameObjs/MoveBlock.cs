using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using InfinityGame.Stage;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class MoveBlock : Block
    {
        private Vector2 speed;
        public MoveBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            speed = new Vector2(5, 0);
        }

        public MoveBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            speed = new Vector2(5, 0);
        }
        public override void Update(GameTime gameTime)
        {
            AddVelocity(speed, VeloParam.Run);
            base.Update(gameTime);
        }
        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara)
            {
                obj.AddVelocity(speed, VeloParam.Run);
            }
            if (obj is Block b)
            {
                var rect = (RectangleF)obj.ISpace;
                List<Line> lines = new List<Line>();
                for (int i = 0; i < 4; i++)
                {
                    if (ISpace.Intersects(rect.GetLine(i)))
                    {
                        lines.Add(rect.GetLine(i));
                    }
                }
                if (lines.Count > 0)
                {
                    Line targetLine = lines[0];
                    float inslength = 0;
                    foreach (var l in lines)
                    {
                        if (ISpace.Contains(l))
                        {
                            targetLine = l;
                            break;
                        }
                    }
                    var ve = targetLine.Center - rect.Center;
                    Console.WriteLine(ve);
                    ve.Normalize();
                    Vector2 newspeed;
                    newspeed = speed - 2 * Vector2.Dot(speed, ve) * ve;
                    speed = newspeed;
                }
            }
            base.CalCollision(obj);
        }
    }
}
