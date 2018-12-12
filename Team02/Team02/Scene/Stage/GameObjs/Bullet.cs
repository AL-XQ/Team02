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
            AddVelocity(speed, VeloParam.Run);
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
                foreach(var l in list)
                {
                    if (l is Chara c)
                    {
                        graC.Charas.Add(c);
                        c.Color = Color.Purple;
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
