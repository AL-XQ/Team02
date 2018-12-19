using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using InfinityGame.GameGraphics;
using InfinityGame.Device;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage;
using InfinityGame;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public abstract class Chara : GameObj
    {
        private D_Void _Update;
        private D_Void _LastUpdate;

        private int hp;
        private int mp;
        private int maxhp = 100;
        private int maxmp = 100;
        private float targetRotation;
        private float rotationIncrement;
        private Vector2 gra = Vector2.Zero;
        private Dictionary<string, Vector2> forces = new Dictionary<string, Vector2>();
        private Dictionary<string, float> disSpeeds = new Dictionary<string, float>();
        private Dictionary<string, object> objMemory = new Dictionary<string, object>();
        private Vector2 accel = Vector2.Zero;//質量を１と考え、加えた力がそのまま加速度になる
        private Vector2 speed = Vector2.Zero;
        private float maxSpeed;
        private bool canJump = false;
        private bool lastIsStrut = false;
        private bool checkLastIsStrut = true;
        private bool isStrut = false;
        private bool rotating = false;
        private Motion motion;
        private Bullet bullet;
        private GraChanger graChanger;


        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Maxhp { get => maxhp; set => maxhp = value; }
        public int Maxmp { get => maxmp; set => maxmp = value; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public CharaManager CharaManager { get => base_Stage.CharaManager; }
        public Motion Motion { get => motion; }
        /// <summary>
        /// 力
        /// </summary>
        public Dictionary<string, Vector2> Forces { get => forces; }
        /// <summary>
        /// 重力
        /// </summary>
        public Vector2 Gra { get => gra; set => SetGra(value); }
        /// <summary>
        /// 立っているかどうか
        /// </summary>
        public bool IsStrut { get => isStrut; }
        public Bullet Bullet { get => bullet; }
        public GraChanger GraChanger { get => graChanger; set => graChanger = value; }
        public bool LastIsStrut { get => lastIsStrut; }
        public bool CanJump { get => canJump; }
        public Dictionary<string, float> DisSpeeds { get => disSpeeds; }
        public bool Rotating { get => rotating; }
        public Dictionary<string, object> ObjMemory { get => objMemory; }
        public bool CheckLastIsStrut { get => checkLastIsStrut; set => checkLastIsStrut = value; }

        public Chara(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
            MovePriority = 5;
            CrimpGroup = "chara";
        }

        public Chara(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            IsCrimp = true;
            MovePriority = 5;
            CrimpGroup = "chara";
        }

        private void SetIsStrut(bool value)
        {
            isStrut = value;
            SetCanJump(isStrut);
        }

        private void SetCanJump(bool value)
        {
            canJump = value;
            DisJump();
        }

        private void SetGra(Vector2 value)
        {
            gra = value;
            targetRotation = (float)(Math.Atan2(value.Y, value.X) - Math.PI / 2);
            rotating = true;
            _Update += RotateToGra;
            //rotationIncrement = FormatRota(targetRotation - Rotation) * 0.1f;ここに書いたら不具合が起こる
        }

        public override void Initialize()
        {
            gra = base_Stage.DefGra;
            forces.Clear();
            accel = Vector2.Zero;
            speed = Vector2.Zero;
            maxSpeed = 20;
            hp = maxhp;
            mp = maxhp;
            Origin = ISpace.LCenter;
            SetUpdate();
            base.Initialize();
        }

        private void SetUpdate()
        {
            _Update = null;
            _Update += CheckStatus;
            _Update += CalForce;
            //_Update += RotateToGra;

            _LastUpdate = null;
            _LastUpdate += DisStrut;
        }

        public override void PreLoadContent()
        {
            motion = new Motion(this);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _Update?.Invoke();
            base.Update(gameTime);
            _LastUpdate?.Invoke();
        }

        private void CheckStatus()
        {
            if (hp <= 0)
            {
                Kill();
            }
            if (speed.LengthSquared() >= 361)
                Color = Color.Green;
            else
                Color = Color.White;
        }

        /// <summary>
        /// 衝突判定の後で処理する
        /// </summary>
        /// <param name="gameTime"></param>
        public override void AfterUpdate(GameTime gameTime)
        {
            motion.Update();
            base.AfterUpdate(gameTime);
        }

        private void DisSpeed()
        {
            if (speed == Vector2.Zero)
                return;
            foreach (var l in disSpeeds.Values)
            {
                var dSpeed = speed * l;
                speed -= dSpeed;
                if (speed.LengthSquared() < 0.01f)
                {
                    speed = Vector2.Zero;
                    return;
                }
            }
            disSpeeds.Clear();
        }

        public void DisStrut()
        {
            lastIsStrut = IsStrut;
            checkLastIsStrut = true;
            SetIsStrut(false);
            if (!lastIsStrut)
                forces["strut"] = Vector2.Zero;
        }

        public override void CalCollision(StageObj obj)
        {
            base.CalCollision(obj);
        }

        /// <summary>
        /// 地面につくときに重力とバランスを取り、落下を止める
        /// </summary>
        public void Strut()
        {
            if (checkLastIsStrut && lastIsStrut)
            {
                SetIsStrut(true);
                return;
            }
            if (gra == Vector2.Zero)
                return;
            SetIsStrut(true);
            var gv = gra;
            forces["strut"] = -gv * 0.95f;//衝突させるため、0.95f出ないと、地面接触判定が不安定
            gv.Normalize();
            float dot = Vector2.Dot(speed, gv);
            Vector2 dg = gv * dot;//重力方向の速度
            speed -= dg;
        }

        /// <summary>
        /// 自分のローカル力をワールド力に変換し、且つ代入
        /// </summary>
        /// <param name="forceName">ベクトル名</param>
        /// <param name="force">ローカルベクトル</param>
        public void RunOnGra(string forceName, Vector2 force)
        {
            Vector2 ve = GetVeOnGra(force);
            forces[forceName] = ve;
        }

        /// <summary>
        /// 自分のローカル力をワールド力に変換し、返す
        /// </summary>
        /// <param name="force">ローカルベクトル</param>
        public Vector2 GetVeOnGra(Vector2 force)
        {
            if (force == Vector2.Zero)
                return Vector2.Zero;
            Vector2 ve = new Vector2(force.X * gra.Y + force.Y * gra.X, force.Y * gra.Y - gra.X * force.X);
            ve.Normalize();
            ve *= force.Length();
            return ve;
        }

        /// <summary>
        /// 自分のワールドベクトルをローカルに変換し、返す
        /// </summary>
        /// <param name="ve"></param>
        /// <returns></returns>
        public Vector2 VeWorldToLocal(Vector2 wve)
        {
            if (wve == Vector2.Zero)
                return Vector2.Zero;
            Vector2 ve = new Vector2(gra.Y * wve.X + gra.X * wve.Y, -(gra.X * wve.X - gra.Y * wve.Y));
            ve.Normalize();
            ve *= wve.Length();
            return ve;
        }

        private void ClearSpeed()
        {
            speed = Vector2.Zero;
        }

        private void CalForce()
        {
            accel = gra;
            foreach (var l in forces.Values)
            {
                accel += l;
            }
            speed += accel;
            if (speed.LengthSquared() > maxSpeed * maxSpeed)
            {
                speed.Normalize();
                speed *= maxSpeed;
            }
            AddVelocity(speed, VeloParam.Run);
            DisSpeed();
        }

        public void ResetGra()
        {
            Gra = base_Stage.DefGra;
        }

        public void Jump(float force)
        {
            if (!canJump || gra == Vector2.Zero)
                return;
            var fg = -gra;
            fg.Normalize();
            fg *= force;
            forces["jump"] = fg;
        }

        private void DisJump()
        {
            forces["jump"] = Vector2.Zero;
        }

        public void ClearBullet()
        {
            bullet = null;
        }

        public void Shut(Vector2 ve, int time)
        {
            if (bullet != null)
                return;
            bullet = new Bullet(Stage);
            bullet.Host = this;
            bullet.Coordinate = ISpace.Center;
            bullet.Speed = ve;
            bullet.TimeDown = time;
            bullet.Create();
        }

        public override void UKill()
        {
            CharaManager.Remove(this);
            base.UKill();
        }

        /// <summary>
        /// 重力の方向に向かってキャラクターを回転する
        /// </summary>
        private void RotateToGra()
        {
            rotationIncrement = FormatRota(targetRotation - Rotation) * 0.2f;
            //これは毎回回転した後チェックする必要があるため
            //SetGraに設定してしまうとずっと回転する可能性がある。
            //ここに設定して回転する量を毎回新しく計算する
            Rotation += rotationIncrement;

            if (Math.Abs(rotationIncrement) < 0.001f)
            {
                rotationIncrement = 0;
                Rotation = targetRotation;
                _Update -= RotateToGra;
                rotating = false;
            }
        }

        /// <summary>
        /// 角度をフォーマットする±π以内に抑える
        /// </summary>
        /// <param name="rota"></param>
        /// <returns></returns>
        private float FormatRota(float rota)
        {
            float pi = (float)Math.PI;
            if (rota <= pi && rota >= -pi)//角度が±180度以内の場合そのままリターンする
                return rota;
            if (rota > pi)//角度が180度以上の場合-360度、Math.Atan2を使っているため、540度以上の角度は出ない
                return rota - 2 * pi;
            return rota + 2 * pi;//残りは角度が-180度以下の場合+360度、Math.Atan2を使っているため、-540度以上の角度は出ない
        }

        public override void Draw2(GameTime gameTime)
        {
            if (graChanger != null && graChanger.OverTime == -1)
            {
                Vector2 loc = -Size.ToVector2() * new Vector2(0.5f, 0.5f);
                Vector2 siz = Size.ToVector2() * new Vector2(1f, 1f);
                spriteBatch.Draw(GraChanger.ControlC.ImageT[0], new Rectangle(DrawLocation + (loc * Stage.CameraScale).ToPoint(), ((Size.ToVector2() + siz) * Stage.CameraScale).ToPoint()), new Rectangle(Point.Zero, GraChanger.ControlC.Size.ToPoint()), Color * refract, Rotation, ((Origin - loc) / (Size.ToVector2() + siz)) * GraChanger.ControlC.Size.ToVector2(), SpriteEffects.None, 1f);
            }
            base.Draw2(gameTime);
        }
    }
}
