using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;

using InfinityGame.Device;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public class GameObj : StageObj
    {
        public GameObj(BaseDisplay aParent) : base(aParent)
        {
            BeAffect = true;
            
        }

        public GameObj(BaseDisplay aParent, string aName) : base(aParent, aName)
        {

        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("chat.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            AddVelocity(new Vector2(1, 1), InfinityGame.Stage.VeloParam.Run);
            base.Update(gameTime);
        }
    }
}
