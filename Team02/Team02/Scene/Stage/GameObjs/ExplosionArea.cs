using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Element;

using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public class ExplosionArea : GameObj
    {
        private ExplosionArea(BaseDisplay aParent) : base(aParent)
        {
            ESpace = ESpace.Cir;
        }

        protected override void SetImage()
        {
            ImageName = "BurstSize.png";
        }

        public static ExplosionArea Create(Base_Stage stage, Vector2 center, float radius)
        {
            var ea = new ExplosionArea(stage);
            Size sz = new Size(radius, radius);
            ea.Coordinate = center - sz.ToVector2();
            ea.Size = sz * 2;
            ea.Radius = radius;
            ea.Origin = sz.ToVector2();
            ea.Create();
            return ea;
        }
    }
}
