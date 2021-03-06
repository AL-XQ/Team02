﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using InfinityGame.Stage;

using Team02.Scene.Stage.GameObjs.Actor;
using Team02.Device;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class MoveBlock : Block
    {
        private Vector2 speed;
        private bool speedChanged = false;

        public Vector2 Speed { get => speed; set => SetSpeed(value); }

        public MoveBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            
        }

        public MoveBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            if (args.ContainsKey("other"))
            {
                var otherArgs = TextReader.Read((string)args["other"]);
                if (otherArgs.ContainsKey("speed"))
                {
                    var values = otherArgs["speed"].Split(',');
                    speed = new Vector2(int.Parse(values[0]), int.Parse(values[1]));
                }
            }
        }

        private void SetSpeed(Vector2 value)
        {
            if(speedChanged)
            {
                return;
            }
            speed = ElementTools.FormatFourGra(value);
            speedChanged = true;
        }

        public override void Update(GameTime gameTime)
        {
            speedChanged = false;
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
                    ve.Normalize();
                    Vector2 newspeed;
                    newspeed = speed - 2 * Vector2.Dot(speed, ve) * ve;
                    Speed = newspeed;
                }
            }
            base.CalCollision(obj);
        }
    }
}
