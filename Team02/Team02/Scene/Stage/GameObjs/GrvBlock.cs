using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class MovingBlock : Block
    {
        public MovingBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public MovingBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
    }
}
