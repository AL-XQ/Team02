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

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Chara : GameObj
    {
        private int hp;
        private int mp;
        private int maxhp = 100;
        private int maxmp = 100;
        private Vector2 gra = Vector2.Zero;
        private Vector2 graSpeed = Vector2.Zero;
        private Vector2 speed = Vector2.Zero;


        public int Hp { get => hp; set => hp = value; }
        public int Mp { get => mp; set => mp = value; }
        public int Maxhp { get => maxhp; set => maxhp = value; }
        public int Maxmp { get => maxmp; set => maxmp = value; }
        public Vector2 Speed { get => speed; set => speed = value; }

        public Chara(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
        }

        public override void Initialize()
        {
            graSpeed = new Vector2(0, 1);
            hp = maxhp;
            mp = maxhp;
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            CalGra();
            AddVelocity(speed, VeloParam.Run);
            DisSpeed();
            base.Update(gameTime);
        }

        public override void CalCollision(StageObj obj)
        {
            base.CalCollision(obj);
        }

        private void DisSpeed()
        {
            
        }

        private void CalGra()
        {
            graSpeed += gra;
            gra = Vector2.Zero;
            speed += graSpeed;
        }

        public void ClearGraSpeed()
        {
            graSpeed = Vector2.Zero;
        }
    }
}
