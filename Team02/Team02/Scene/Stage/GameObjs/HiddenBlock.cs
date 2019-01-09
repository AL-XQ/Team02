using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage.GameObjs
{
    public class HiddenBlock : LoopedBlock
    {
        private bool isPush;
        public HiddenBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
            isPush = false;
        }

        public HiddenBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            IsCrimp = true;
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Hero)
            {
                isPush = true;
            }
            base.CalCollision(obj);
        }
        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void SetImage()
        {
            ImageName = "bullet_test.png";
        }
        public override void Update(GameTime gameTime)
        {
            if (isPush)
            {
                Kill();
            }
            base.Update(gameTime);
        }
    }
}
