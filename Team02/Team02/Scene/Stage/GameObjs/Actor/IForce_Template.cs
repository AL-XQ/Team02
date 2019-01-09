#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.Element;
using InfinityGame.Stage;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.API;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public abstract class IForce_Template : IGraChange
    {
        #region コピーしない内容
        private Base_Stage base_Stage;
        public Color Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public abstract void AddVelocity(Vector2 speed, VeloParam vp);
        private D_Void _Update;
        private D_Void _LastUpdate;
        public ISpace ISpace => throw new NotImplementedException();
        #endregion

        #region コピーする内容
        #region フィールド


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
        #endregion フィールド

        #region メソッド

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
        #endregion メソッド
        #endregion コぴーする内容
        #region 追加する内容
        //Initializeの中追加
        public void Initialize()
        {
            //この以下追加
            gra = base_Stage.DefGra;
            forces.Clear();
            accel = Vector2.Zero;
            speed = Vector2.Zero;
            maxSpeed = 20;
            SetUpdate();
            //この上追加
        }
        #endregion 追加する内容
    }
}
#endif
