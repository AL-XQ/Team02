using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02
{
    public static class ElementTools
    {
        /// <summary>
        /// veを四つの方向にフォーマット
        /// </summary>
        /// <param name="ve"></param>
        /// <returns></returns>
        public static Vector2 FormatFourGra(Vector2 ve)
        {
            var ret = Vector2.Zero;
            if (Math.Abs(ve.X) >= Math.Abs(ve.Y))
            {
                if (ve.X >= 0)
                {
                    ret = new Vector2(1, 0) * ve.Length();
                    return ret;
                }
                ret = new Vector2(-1, 0) * ve.Length();
                return ret;
            }
            if (ve.Y >= 0)
            {
                ret = new Vector2(0, 1) * ve.Length();
                return ret;
            }
            ret = new Vector2(0, -1) * ve.Length();
            return ret;
        }


        /// <summary>
        /// 自分のワールドベクトルをローカルに変換し、返す
        /// </summary>
        /// <param name="ve"></param>
        /// <returns></returns>
        public static Vector2 VeWorldToLocal(Vector2 gra, Vector2 wve)
        {
            if (wve == Vector2.Zero)
                return Vector2.Zero;
            Vector2 ve = new Vector2(gra.Y * wve.X + gra.X * wve.Y, -(gra.X * wve.X - gra.Y * wve.Y));
            ve.Normalize();
            ve *= wve.Length();
            return ve;
        }

        /// <summary>
        /// 自分のローカル力をワールド力に変換し、返す
        /// </summary>
        /// <param name="force">ローカルベクトル</param>
        public static Vector2 GetVeOnGra(Vector2 gra, Vector2 force)
        {
            if (force == Vector2.Zero)
                return Vector2.Zero;
            Vector2 ve = new Vector2(force.X * gra.Y + force.Y * gra.X, force.Y * gra.Y - gra.X * force.X);
            ve.Normalize();
            ve *= force.Length();
            return ve;
        }
    }
}
