using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using InfinityGame.Stage;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class MoveBlock : Block
    {
        private float speed;
        public MoveBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            speed = 5;
        }

        public MoveBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            speed = 5;
        }
        public override void Update(GameTime gameTime)
        {
            AddVelocity(new Vector2(speed, 0), VeloParam.Run);
            base.Update(gameTime);
        }
        public override void CalCollision(StageObj obj)
        {
            if(obj is Chara)
            {
              obj.AddVelocity(new Vector2(speed, 0), VeloParam.Run);
            }
            if(obj is Block)
            {
                speed = -speed;
            }
            base.CalCollision(obj);
        }
    }
}
