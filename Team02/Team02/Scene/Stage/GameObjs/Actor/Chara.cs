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
        private Vector2 gra = Vector2.Zero;
        private Dictionary<string, Vector2> forces = new Dictionary<string, Vector2>();
        private Vector2 accel = Vector2.Zero;//質量を１と考え、加えた力がそのまま加速度になる
        private Vector2 speed = Vector2.Zero;
        private float maxSpeed;
        private bool canJump = false;
        private bool isStrut = false;
        private Motion motion;
        private string imageName;

        protected Base_Stage base_Stage;


        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Maxhp { get => maxhp; set => maxhp = value; }
        public int Maxmp { get => maxmp; set => maxmp = value; }
        public Vector2 Speed { get => speed; set => speed = value; }
        public CharaManager CharaManager { get => base_Stage.CharaManager; }
        public Motion Motion { get => motion; }
        /// <summary>
        /// 画像の名前
        /// </summary>
        public string ImageName { get => imageName; set => SetImageName(value); }
        /// <summary>
        /// 力
        /// </summary>
        public Dictionary<string, Vector2> Forces { get => forces; }
        /// <summary>
        /// 重力
        /// </summary>
        public Vector2 Gra { get => gra; set => gra = value; }
        /// <summary>
        /// 立っているかどうか
        /// </summary>
        public bool IsStrut { get => isStrut; }

        public Chara(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
            base_Stage = (Base_Stage)aParent;
            MovePriority = 5;
        }

        private void SetImageName(string value)
        {
            imageName = value;
            if (imageName != null)
                Image = ImageManage.GetSImage(imageName);
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
            SetImage();
            OffSet();
            base.LoadContent();
        }

        protected virtual void OffSet()
        {

        }

        protected virtual void SetImage()
        {

        }

        public override void Update(GameTime gameTime)
        {

            motion.CheckDire();
            motion.CheckMotion();
            //Console.WriteLine(motion.Dire);
            //Console.WriteLine(motion.State);
            CalForce();
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
            gra = base_Stage.DefGra;
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
    }
}
