using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Team02.Scene.Stage.GameObjs.Actor;

using InfinityGame.Device.KeyboardManage;
using InfinityGame.Def;
using InfinityGame.Stage;

namespace Team02.Scene
{
    public class Player
    {
        private Chara chara;

        public Chara Chara { get => chara; set => chara = value; }
        public Player()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            if (chara != null)
            {
                Vector2 ve = GameKeyboard.GetVelocity(IGConfig.PlayerKeys);
                chara.AddVelocity(ve, VeloParam.Run);
                Jump();
            }
        }
        public void Jump()
        {
            if (GameKeyboard.GetKeyTrigger(Keys.Space))
                chara.Speed += new Vector2(0, -5);
        }
    }
}
