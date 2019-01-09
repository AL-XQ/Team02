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
        private Vector2 gra = Vector2.Zero;
        private Vector2 accel = Vector2.Zero;
        private bool isStrut = false;
        private bool lastIsStrut;
        private bool checkLastIsStrut = true;
        private Dictionary<string, Vector2> forces = new Dictionary<string, Vector2>();
        private Dictionary<string, float> disSpeeds = new Dictionary<string, float>();
        private Vector2 speed = Vector2.Zero;
        private float maxSpeed;
        private GraChanger graChanger;
        public Vector2 Gra { get => gra; set => SetGra(value); }

        public bool IsStrut { get => isStrut; }

        public bool LastIsStrut { get => lastIsStrut; }

        public bool CheckLastIsStrut { get => checkLastIsStrut; set => checkLastIsStrut = value; }

        public Dictionary<string, Vector2> Forces { get => forces; }

        public Dictionary<string, float> DisSpeeds { get => disSpeeds; }

        public Vector2 Speed { get => speed; set => speed = value; }
        public GraChanger GraChanger { get => graChanger; set => graChanger = value; }

        public GraBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CrimpGroup = "";
            BeMove = true;
        }

        public GraBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CrimpGroup = "";
            BeMove = true; ;
        }

        public override void Initialize()
        {
            gra = base_Stage.DefGra;
            forces.Clear();
            accel = Vector2.Zero;
            speed = Vector2.Zero;
            maxSpeed = 20;
            SetUpdate();
            base.Initialize();
        }

        private void SetIsStrut(bool value)
        {
            isStrut = value;
        }

        private void SetGra(Vector2 value)
        {
            gra = value;
        }

        public void DisStrut()
        {
            lastIsStrut = IsStrut;
            checkLastIsStrut = true;
            SetIsStrut(false);
            if (!lastIsStrut)
                forces["strut"] = Vector2.Zero;
        }

        public void ResetGra()
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
    }
}
