using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Device;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs.Actor;
using Team02.Scene.Stage.GameObjs.API;

namespace Team02.Scene.Stage.GameObjs
{
    public class Bullet : GameObj
    {
        private Chara host;
        private Vector2 speed = Vector2.Zero;
        private int timeDown = 0;

        public Vector2 Speed { get => speed; set => speed = value; }

        public Chara Host { get => host; set => host = value; }
        public int TimeDown { get => timeDown; set => timeDown = value; }

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
            sounds["impact"] = SoundManage.GetSound("Bullet_Impact.wav");
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
            CountDown();
            base.Update(gameTime);
        }

        private void CountDown()
        {
            if (timeDown > 0)
            {
                timeDown--;
                return;
            }
            Kill();
        }

        public override void CalCollision(StageObj obj)
        {
            if ((obj is Block || obj is Enemy) && !Dealing)
            {
                float rad = 64f;
                Vector2 lo = ISpace.Center - new Vector2(rad, rad);
                var cir = new Circle(lo, rad);
                var nlist = Stage.DetectorObj(cir);
                var list = new List<StageObj>();
                foreach(var l in nlist)
                {
                    if ((l is IGraChange gc && gc.EnableChange) || l is IGraLink)
                        list.Add(l);
                }
                if (list.Count==0)
                {
                    Kill();
                    base.CalCollision(obj);
                    return;
                }
                var graC = new GraChanger(base_Stage);
                graC.Center = ISpace.Center;
                ExplosionArea.Create(base_Stage, ISpace.Center, rad);

                List<IGraChange> gcl = new List<IGraChange>();
                foreach (var l in list)
                {
                    if (l is IGraChange gc && gc.EnableChange)
                    {
                        if (!gcl.Contains(gc))
                            gcl.Add(gc);
                    }
                    else if (l is IGraLink gl)
                    {
                        if (gl.GraObj != null && !gcl.Contains(gl.GraObj))
                            gcl.Add(gl.GraObj);
                    }
                }
                foreach (var l in gcl)
                {
                    l.ImpleGraChanger(graC, gcl);
                }
                Kill();
            }
            base.CalCollision(obj);
        }

        public override void UKill()
        {
            sounds["impact"].PlayE();
            host.ClearBullet();
            base.UKill();
        }
    }
}
