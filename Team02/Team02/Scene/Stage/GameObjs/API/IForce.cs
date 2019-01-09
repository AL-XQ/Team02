using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using InfinityGame.Element;

namespace Team02.Scene.Stage.GameObjs.API
{
    public interface IForce : ISpeed
    {
        Vector2 Gra { get; set; }
        bool IsStrut { get; }
        bool LastIsStrut { get; }
        bool CheckLastIsStrut { get; set; }
        ISpace ISpace { get; }
        void ResetGra();
        void DisStrut();
        void Strut();
        void ResetMovePriority();
        Dictionary<string, Vector2> Forces { get; }
        Dictionary<string, float> DisSpeeds { get; }
    }
}
