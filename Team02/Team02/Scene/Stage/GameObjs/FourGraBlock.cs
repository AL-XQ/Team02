using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public class FourGraBlock : GraBlock
    {
        public FourGraBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public FourGraBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
        }

        protected override void SetGra(Vector2 value)
        {
            gra = ElementTools.FormatFourGra(value);
        }

        public override void ResetGra()
        {
            Gra = Vector2.Zero;
            Forces.Clear();
            Speed = Vector2.Zero;
        }
    }
}
