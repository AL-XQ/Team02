using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Team02.Scene.Stage.GameObjs.Actor;
using Team02.Scene.Stage;

using InfinityGame.Device.KeyboardManage;
using InfinityGame.Def;
using InfinityGame.Stage;
using InfinityGame;

namespace Team02.Scene
{
    public class Player
    {
        private Chara chara;
        private PlayScene playScene;
        private Vector2 cameraCenter = Vector2.Zero;

        public Chara Chara { get => chara; set => chara = value; }
        public Base_Stage Stage { get => (Base_Stage)playScene.ShowStage; }
        public Vector2 CameraCenter { get => cameraCenter; set => cameraCenter = value; }

        public Player(PlayScene playScene)
        {
            this.playScene = playScene;
        }

        public void Update(GameTime gameTime)
        {
            ContorlChara();
        }

        private void ContorlChara()
        {
            if (chara != null)
            {
                Vector2 ve = GameKeyboard.GetVelocity(IGConfig.PlayerKeys) * 10;
                chara.AddVelocity(ve, VeloParam.Run);
                Jump();
                if (GameKeyboard.GetKeyState(Keys.Enter))
                    chara.Rotation += 0.05f;
                CheckChara();
            }
        }

        private void Jump()
        {
            if (GameKeyboard.GetKeyTrigger(Keys.Space))
                chara.Speed += new Vector2(0, -5);
        }

        private void CheckChara()
        {
            CheckCoo();
            void CheckCoo()
            {
                if (chara.Coordinate.X >= IGConfig.screen.Width / 2)
                {
                    cameraCenter.X = chara.Coordinate.X;
                    Stage.CameraCenter = cameraCenter;
                }
            }
        }
    }
}
