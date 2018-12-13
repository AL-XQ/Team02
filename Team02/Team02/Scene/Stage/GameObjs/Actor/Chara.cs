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
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public abstract class Chara : GameObj
    {
        private int hp;
        private int mp;
        private int maxhp = 100;
        private int maxmp = 100;
        private float targetRotation;
        private float rotationIncrement;
        private Vector2 gra = Vector2.Zero;
        private Dictionary<string, Vector2> forces = new Dictionary<string, Vector2>();
        private Vector2 accel = Vector2.Zero;//質量を１と考え、加えた力がそのまま加速度になる
        private Vector2 speed = Vector2.Zero;
        private float maxSpeed;
        private bool canJump = false;
        private bool isStrut = false;
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
            base.Initialize();
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
            if (hp <= 0)
                if (hp <= 0)
                {
                    Kill();
                }
            motion.CheckDire();
            motion.CheckMotion();
            CalForce();
            RotateToGra();
            base.Update(gameTime);

            DisStrut();
        }

        public override void AfterUpdate(GameTime gameTime)
        {
            base.AfterUpdate(gameTime);
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Block)
            {
                canJump = true;
            }
            base.CalCollision(obj);
        }

        /// <summary>
        /// 摩擦力により減速処理
        /// </summary>
        public void DisSpeed(float coeff)
        {
            if (speed == Vector2.Zero)
                return;
            var dSpeed = speed * coeff;
            speed -= dSpeed;
            if (speed.LengthSquared() < 0.01f)
                speed = Vector2.Zero;
        }

        public void DisStrut()
        {
            isStrut = false;
            canJump = false;
            forces["strut"] = Vector2.Zero;
        }

        /// <summary>
        /// 地面につくときに重力とバランスを取り、落下を止める
        /// </summary>
        public void Strut()
        {
            if (gra == Vector2.Zero)
                return;
            isStrut = true;
            var gv = gra;
            forces["strut"] = -gv;
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

        public void DisJump()
        {
            forces["jump"] = Vector2.Zero;
        }

        public void ClearBullet()
        {
            bullet = null;
        }

        public void Shut(Vector2 ve)
        {
            if (bullet != null)
                return;
            bullet = new Bullet(Stage);
            bullet.Host = this;
            bullet.Coordinate = ISpace.Center;
            bullet.Speed = ve;
            bullet.Create();
        }

        public override void UKill()
        {
            //死亡したら各クラスの制御
            base.UKill();
        }

        /// <summary>
        /// 重力の方向に向かってキャラクターを回転する
        /// </summary>
        private void RotateToGra()
        {
            Rotation += rotationIncrement;

            if (Math.Abs(Rotation - targetRotation) < 0.01f)
            {
                rotationIncrement = 0;
                Rotation = targetRotation;
            }
        }

        private void SetGra(Vector2 value)
        {
            gra = value;
            targetRotation = (float)Math.Atan2(value.Y, value.X) - MathHelper.ToRadians(90);
            rotationIncrement = (targetRotation - Rotation) * 0.1f;

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
