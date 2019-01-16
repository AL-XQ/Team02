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

using Team02.Scene.Stage.GameObjs.API;
using InfinityGame.Stage;

namespace Team02.Scene.Stage.GameObjs
{
    public class GraBlock : Block, IGraChange
    {
        protected Vector2 gra = Vector2.Zero;
        private Vector2 accel = Vector2.Zero;
        private bool isStrut = false;
        private bool lastIsStrut;
        private bool checkLastIsStrut = true;
        private Dictionary<string, Vector2> forces = new Dictionary<string, Vector2>();
        private Dictionary<string, float> disSpeeds = new Dictionary<string, float>();
        private Vector2 speed = Vector2.Zero;
        private float maxSpeed;
        private bool enableChange = true;
        private GraChanger graChanger;
        private int stabilityTime = 0;
        private int stabilityTarget = 60;
        private float stabilitySpeed = 0.2f;
        private int defaultMovePri = 5;

        public int StabilityTime { get => stabilityTime; set => SetStabilityTime(value); }

        public Vector2 Gra { get => gra; set => SetGra(value); }

        public bool IsStrut { get => isStrut; }

        public bool LastIsStrut { get => lastIsStrut; }

        public bool CheckLastIsStrut { get => checkLastIsStrut; set => checkLastIsStrut = value; }

        public Dictionary<string, Vector2> Forces { get => forces; }

        public Dictionary<string, float> DisSpeeds { get => disSpeeds; }

        public Vector2 Speed { get => speed; set => speed = value; }
        public GraChanger GraChanger { get => graChanger; set => graChanger = value; }
        public int DefaultMovePri { get => defaultMovePri; set => defaultMovePri = value; }
        public bool EnableChange { get => enableChange; set => enableChange = value; }

        public GraBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CrimpGroup = "";
            defaultMovePri = 5;
            BeMove = true;
        }

        public GraBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CrimpGroup = "";
            defaultMovePri = 5;
            BeMove = true; ;
        }

        public override void Initialize()
        {
            MovePriority = defaultMovePri;
            ResetGra();
            forces.Clear();
            accel = Vector2.Zero;
            speed = Vector2.Zero;
            maxSpeed = 20;
            SetUpdate();
            base.Initialize();
        }

        private void SetStabilityTime(int value)
        {
            stabilityTime = Math.Min(value, stabilityTarget);
            if (stabilityTime == stabilityTarget - 1)
                Stability();
        }

        private void SetIsStrut(bool value)
        {
            isStrut = value;
        }

        protected virtual void SetGra(Vector2 value)
        {
            gra = value;
        }

        public virtual void ResetMovePriority()
        {
            MovePriority = DefaultMovePri;
        }

        public override void CalPreCrimp(StageObj obj)
        {
            ResetMovePriority();
            if (obj is IForce f)
            {
                if (obj is Chara && (f.Gra + gra).LengthSquared() <= 0.01f)
                {
                    var dg = GetVectorByDire(speed, gra);
                    Speed -= dg;
                }
                else if (CheckIForceOn(f))
                {
                    f.ResetMovePriority();
                    MovePriority = obj.MovePriority - 1;
                }
            }
            base.CalPreCrimp(obj);
        }

        public void DisStrut()
        {
            lastIsStrut = IsStrut;
            checkLastIsStrut = true;
            SetIsStrut(false);
            if (!lastIsStrut)
                forces["strut"] = Vector2.Zero;
        }

        public virtual void ResetGra()
        {
            Gra = base_Stage.DefGra;
        }

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
            Vector2 dg = GetVectorByDire(speed, gv);
            speed -= dg;
        }

        public Vector2 GetVectorByDire(Vector2 ve, Vector2 dire)
        {
            dire.Normalize();
            float dot = Vector2.Dot(ve, dire);
            Vector2 dg = dire * dot;//重力方向の速度
            return dg;
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
            return ElementTools.GetVeOnGra(gra, force);
        }

        /// <summary>
        /// 自分のワールドベクトルをローカルに変換し、返す
        /// </summary>
        /// <param name="ve"></param>
        /// <returns></returns>
        public Vector2 VeWorldToLocal(Vector2 wve)
        {
            return ElementTools.VeWorldToLocal(gra, wve);
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

        private void SetUpdate()
        {
            _Update = null;
            _Update += CalForce;

            _LastUpdate = null;
            _LastUpdate += DisStrut;
        }

        private void Stability()
        {
            Speed = Vector2.Zero;
            Forces.Clear();
            Forces["strut"] = -Gra * 0.95f;
        }

        public override void AfterUpdate(GameTime gameTime)
        {
            if ((Coordinate - LastCoordinate).LengthSquared() <= stabilitySpeed * stabilitySpeed)
                StabilityTime++;
            else
                StabilityTime = 0;
            base.AfterUpdate(gameTime);
        }

        public virtual void ImpleGraChanger(GraChanger graC, List<IGraChange> gcl)
        {
            bool imple = true;

            foreach(var l in gcl)
            {
                if (l is Chara)
                {
                    imple = false;
                    break;
                }
            }

            if (imple)
            {
                graC.Objs.Add(this);
                Color = Color.Pink;
                GraChanger = graC;
            }
        }
    }
}
