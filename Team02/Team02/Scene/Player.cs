using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Team02.Scene.Stage.GameObjs.Actor;
using Team02.Scene.Stage;
using Team02.Scene.Stage.GameObjs;

using InfinityGame.Device.KeyboardManage;
using InfinityGame.Def;
using InfinityGame.Stage;
using InfinityGame;
using InfinityGame.Element;
using InfinityGame.Device.MouseManage;

namespace Team02.Scene
{
    public class Player
    {
        private Chara chara;
        private PlayScene playScene;
        private Vector2 cameraCenter;
        private float jumpForce = 15;
        private GameMouse gameMouse;
        private D_Void _Click;
        private bool a = false;

        public Chara Chara { get => chara; set => chara = value; }
        public Base_Stage Stage { get => (Base_Stage)playScene.ShowStage; }
        public Vector2 CameraCenter { get => cameraCenter; set => cameraCenter = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public GraChanger NowChanger { get => Stage.NowChanger; }

        public Player(PlayScene playScene)
        {
            this.playScene = playScene;
            gameMouse = GameRun.Instance.GameMouse;
            gameMouse._Click += Player_Click;
            //Test
            _Click = Shut_Click;
            //Test
        }

        public void Update(GameTime gameTime)
        {
            ContorlChara();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            _Click?.Invoke();
        }

        private void Shut_Click()
        {
            if (!a)
            {
                a = true;
                return;
            }

            if (NowChanger == null)
            {
                Vector2 point = gameMouse.MouseState.Position.ToVector2();
                Vector2 coo = playScene.GetStageCoo(point);
                Vector2 ve = coo - chara.ISpace.Center;
                ve.Normalize();
                ve *= 20f;
                ((Hero)chara).Shut(ve, 60);
                return;
            }
            {
                Vector2 point = gameMouse.MouseState.Position.ToVector2();
                Vector2 coo = playScene.GetStageCoo(point);
                Vector2 ve = coo - chara.ISpace.Center;
                ve.Normalize();
                ve *= 0.5f;
                NowChanger.EnableGra(ve);
            }
        }

        private void ContorlChara()
        {
            if (chara != null)
            {
                Vector2 force = GameKeyboard.GetVelocity(IGConfig.PlayerKeys) * 0.4f;
                if (!chara.IsStrut)
                    force.X *= 0.2f;
                chara.RunOnGra("run", force);
                Jump();
                if (GameKeyboard.GetKeyState(Keys.Right))
                {
                    chara.Rotation += 0.05f;
                    chara.Gra = VectorTools.Rotate(Vector2.Zero, chara.Gra, 0.05f);
                }
                else if (GameKeyboard.GetKeyState(Keys.Left))
                {
                    chara.Rotation -= 0.05f;
                    chara.Gra = VectorTools.Rotate(Vector2.Zero, chara.Gra, -0.05f);
                }
                if (GameKeyboard.GetKeyTrigger(Keys.Q))
                {
                    chara.Rotation = 0;
                    chara.ResetGra();
                }
                CheckChara();
            }
        }

        private void Jump()
        {
            if (GameKeyboard.GetKeyTrigger(Keys.Space))
            {
                chara.Jump(jumpForce);
                return;
            }
            chara.DisJump();
        }

        private void CheckChara()
        {
            CheckCoo();
            void CheckCoo()
            {
                if (chara.Coordinate.X >= IGConfig.screen.Width / 2)
                {
                    cameraCenter.X = chara.Coordinate.X;
                }
                if (chara.Coordinate.Y - IGConfig.screen.Height / 4 >= IGConfig.screen.Height / 2)
                {
                    cameraCenter.Y = chara.Coordinate.Y - IGConfig.screen.Height / 4;
                }
                Stage.CameraCenter = cameraCenter;
            }
        }
    }
}
