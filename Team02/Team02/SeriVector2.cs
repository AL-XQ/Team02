using InfinityGame.Element;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02
{
    [Serializable]
    public struct SeriVector2
    {
        public float x, y;
        public SeriVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2(SeriVector2 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static implicit operator SeriVector2(Vector2 v)
        {
            return new SeriVector2(v.X, v.Y);
        }

        public static implicit operator Size(SeriVector2 v)
        {
            return new Size(v.x, v.y);
        }

        public static implicit operator SeriVector2(Size v)
        {
            return new SeriVector2(v.Width, v.Height);
        }
    }
}
