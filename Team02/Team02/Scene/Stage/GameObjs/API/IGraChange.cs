using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.API
{
    public interface IGraChange : IForce
    {
        bool EnableChange { get; }
        GraChanger GraChanger { get; set; }
        Color Color { get; set; }
        void ImpleGraChanger(GraChanger graC, List<IGraChange> gcl);
    }
}
