using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.Device;
using InfinityGame.Element;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public enum MotionState
    {
        Normal,
        Fall,
        Jump,
        Float,
        Walk,
    }

    public enum Direction
    {
        Left,
        Right,
    }

    public class Motion
    {
        private Chara chara;
        private MotionState state;
        private Direction dire;
        private Dictionary<Direction, Dictionary<MotionState, string>> images = new Dictionary<Direction, Dictionary<MotionState, string>>();

        public MotionState State { get => state; set => SetState(value); }
        public Direction Dire { get => dire; }
        public Dictionary<Direction, Dictionary<MotionState, string>> Images { get => images; }

        public Motion(Chara chara)
        {
            this.chara = chara;
            foreach (var l in Enum.GetValues(typeof(Direction)))
            {
                var ll = (Direction)l;
                images[ll] = new Dictionary<MotionState, string>();
            }
            state = MotionState.Normal;
        }

        private void SetState(MotionState state)
        {
            this.state = state;
            chara.ImageName = images[dire][state];
        }

        private void SetDire(Direction value)
        {
            dire = value;
            chara.ImageName = images[dire][state];
        }

        public void CheckDire()
        {
            if (chara.Speed == Vector2.Zero || chara.Gra == Vector2.Zero)
                return;//変更しない
            Line tli = new Line(Vector2.Zero, chara.Gra, VectorTools.Vertical(chara.Gra));
            Vector2Side side = tli.PointAtX(chara.Speed);
            if (side == Vector2Side.X_Plus)
            {
                SetDire(Direction.Left);
                return;
            }
            if (side == Vector2Side.X_Minus)
                SetDire(Direction.Right);
        }
    }
}
