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
        private D_Void _RunZoom;
        private float zoom = 1f;
        private float kickForce = 50f;
        private int kickTime = 180;
        private Chara chara;
        private PlayScene playScene;
        private Vector2 cameraCenter;
        private float jumpForce = 15;
        private GameMouse gameMouse;
        private D_Void _Click;
        private D_Void _RightClick;
        private bool start = false;
#if DEBUG
        private bool edit = false;
        public bool Edit { get => edit; set => SetEdit(value); }
#endif

        public Chara Chara { get => chara; set => SetChara(value); }
        public Base_Stage Stage { get => (Base_Stage)playScene.ShowStage; }
        public Vector2 CameraCenter { get => cameraCenter; set => cameraCenter = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public GraChanger NowChanger { get => Stage.NowChanger; }

        public Player(PlayScene playScene)
        {
            this.playScene = playScene;
            gameMouse = GameRun.Instance.GameMouse;
            gameMouse._Click += Player_Click;
            gameMouse._RightClick += Player_RightClick;
            _Click = Shut_Click;
            _RightClick = Kick;
        }

        public void Initialize()
        {
            start = false;
        }

        private void SetChara(Chara value)
        {
            chara = value;
            if (chara != null)
                chara.Times["kick"] = 0;
        }

        public void Update(GameTime gameTime)
        {
#if DEBUG
            if (GameKeyboard.GetKeyTrigger(Keys.F12))
                Edit = !Edit;
            if (GameKeyboard.GetKeyTrigger(Keys.F11))
                playScene.Initialize();


            if (GameKeyboard.GetKeyTrigger(Keys.D1))
                SetStage("map01");
            if (GameKeyboard.GetKeyTrigger(Keys.D2))
                SetStage("map02");
            if (GameKeyboard.GetKeyTrigger(Keys.D3))
                SetStage("map03");
            if (GameKeyboard.GetKeyTrigger(Keys.D4))
                SetStage("map04");
            if (GameKeyboard.GetKeyTrigger(Keys.D5))
                SetStage("map05");
            if (GameKeyboard.GetKeyTrigger(Keys.D6))
                SetStage("map06");
            if (GameKeyboard.GetKeyTrigger(Keys.D7))
                SetStage("map07");
            if (GameKeyboard.GetKeyTrigger(Keys.D8))
                SetStage("map08");
            if (edit)
            {
                EditModeUpdate();
                return;
            }
#endif
            ContorlChara();
        }

        private void Player_Click(object sender, EventArgs e)
        {
            if (!playScene.Running)
                return;
#if DEBUG
            if (edit)
            {
                EditMode_Click();
                return;
            }
#endif
            _Click?.Invoke();
        }

        private void Player_RightClick(object sender, EventArgs e)
        {
            _RightClick?.Invoke();
        }
#if DEBUG

        private void SetEdit(bool value)
        {
            edit = value;
            playScene.LineUI.Visible = !edit;
        }

        private void EditModeUpdate()
        {
            Vector2 ve = GameKeyboard.GetVelocity(IGConfig.PlayerKeys) * 10f / Stage.CameraScale;
            Stage.CameraCenter += ve;
            if (GameKeyboard.GetKeyTrigger(Keys.Up))
                Stage.CameraScale *= 2f;
            else if (GameKeyboard.GetKeyTrigger(Keys.Down))
                Stage.CameraScale *= 0.5f;
            if (GameKeyboard.GetKeyTrigger(Keys.H))
                Stage.CameraCenter = cameraCenter;
        }

        private void SetStage(string map)
        {
            Stage.Map = map;
            Stage.Initialize();
        }

        private void EditMode_Click()
        {

        }
#endif
        private void Shut_Click()
        {
            if (!start)
            {
                start = true;
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

        private void Kick()
        {
            if (chara.Times["kick"] > 0)
                return;
            Vector2 point = gameMouse.MouseState.Position.ToVector2();
            var ve = playScene.GetStageCoo(point) - chara.ISpace.Center;
            ve.Normalize();
            chara.Speed += ve * kickForce;
            chara.Times["kick"] = kickTime;
        }

        private void ContorlChara()
        {
            if (chara != null)
            {
                Vector2 force = GameKeyboard.GetVelocity(IGConfig.PlayerKeys) * 0.4f;
                if (chara.IsStrut)
                {
                    if (force.Y < 0)
                        force.Y = 0;
                }
                else
                {
                    force.X *= 0.2f;
                    force.Y *= 0.8f;
                }
                chara.RunOnGra("run", force);
                Jump();
                if (GameKeyboard.GetKeyState(Keys.Right))
                {
                    chara.Gra = VectorTools.Rotate(Vector2.Zero, chara.Gra, 0.05f);
                }
                else if (GameKeyboard.GetKeyState(Keys.Left))
                {
                    chara.Gra = VectorTools.Rotate(Vector2.Zero, chara.Gra, -0.05f);
                }
                if (GameKeyboard.GetKeyTrigger(Keys.Q))
                {
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

        public void ResetCamera()
        {
            Stage.CameraLocation = Vector2.Zero;
            CameraCenter = Stage.CameraCenter;
        }

        public void ZoomTo(float zoom)
        {
            this.zoom = zoom;
            _RunZoom = OnZoom;
        }

        private void OnZoom()
        {
            var change = (Stage.CameraScale - zoom) * 0.05f;
            if (Math.Abs(change) > 0.0001f)
                Stage.CameraScale -= change;
            else
            {
                Stage.CameraScale = zoom;
                _RunZoom = null;
            }
        }

        public void Update()
        {
            ZoomTo(1f);
        }

        public void AfterUpdate()
        {
            _RunZoom?.Invoke();
        }
    }
}
