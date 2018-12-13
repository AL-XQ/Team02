using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage.GameObjs
{
    public class Bullet : GameObj
    {
        private Chara host;
        private Vector2 speed = Vector2.Zero;

        public Vector2 Speed { get => speed; set => speed = value; }
        private float flyingspeed;//射出速度
        private int lifeCnt;//存在時間
        private readonly int LIFE = 60;

        public Chara Host { get => host; set => host = value; }

        public Bullet(BaseDisplay aParent) : base(aParent)
        {
            IsCrimp = false;
        }

        public Bullet(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
        }

        public override void PreLoadContent()
        {
            Size = new Size(32, 32);
            Radius = size.Width / 2;
            Origin = (Size / 2).ToVector2();
            ESpace = ESpace.Cir;

            flyingspeed = 2.0f;
            lifeCnt = 0;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void SetImage()
        {
            ImageName = "bullet_test.png";
        }

        protected override void OffSet()
        {
            RenderCoo_Offset = -Size.ToVector2() * new Vector2(0.5f, 0.5f);
            RenderSize_Offset = Size.ToVector2() * Vector2.One;
        }

        public override void Update(GameTime gameTime)
        {
            AddVelocity(speed*flyingspeed, VeloParam.Run);

            lifeCnt++;
            if (lifeCnt > LIFE)
                Kill();


            base.Update(gameTime);
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Block)
            {
                float rad = 64f;
                Vector2 lo = ISpace.Center - new Vector2(rad, rad);
                var cir = new Circle(lo, rad);
                var list = Stage.DetectorObj(cir);
                var graC = new GraChanger(base_Stage);
                graC.Center = ISpace.Center;
                var ea = ExplosionArea.Create(base_Stage, ISpace.Center, rad);
                graC.Ea = ea;

                foreach(var l in list)
                {
                    if (l is Chara c)
                    {
                        graC.Charas.Add(c);
                        c.Color = Color.Pink;
                        c.GraChanger = graC;
                    }
                }
                Kill();
            }
            base.CalCollision(obj);
        }

        public override void UKill()
        {
            host.ClearBullet();
            base.UKill();
        }
    }
}
