using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Element;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Team02.Device;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Hero : Chara
    {
        //残像エフェクト関連
        private SImage trailImage;
        private struct TrailParticle { public Vector2 position; public Timer timer; }
        private List<TrailParticle> trailParticles = new List<TrailParticle>();

        public Hero(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Hero = this;
        }

        public Hero(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CharaManager.Hero = this;
        }

        public override void Initialize()
        {
            DamageSpeed = 40f;
            base.Initialize();
        }

        protected override void OffSet()
        {
            RenderCoo_Offset = -size.ToVector2() * new Vector2(0.25f, 0.5f);
            RenderSize_Offset = size.ToVector2() * new Vector2(0.5f, 0.625f);
        }

        public override void LoadContent()
        {
            trailImage = ImageManage.GetSImage("trail.png");
            base.LoadContent();
        }

        protected override void SetImage()
        {
            Motion.Images[Direction.Right][MotionState.Normal] = "Player_Test.png";
            Motion.Images[Direction.Right][MotionState.Fall] = "state_test_fall.png";
            Motion.Images[Direction.Right][MotionState.Jump] = "state_test_jump.png";
            Motion.Images[Direction.Right][MotionState.Walk] = "state_test_walk.png";
            Motion.Images[Direction.Right][MotionState.Float] = "Player_Test.png";
            Motion.Images[Direction.Left][MotionState.Normal] = "Player_Test_Left.png";
            Motion.Images[Direction.Left][MotionState.Fall] = "state_test_fall.png";
            Motion.Images[Direction.Left][MotionState.Jump] = "state_test_jump.png";
            Motion.Images[Direction.Left][MotionState.Walk] = "state_test_walk.png";
            Motion.Images[Direction.Left][MotionState.Float] = "Player_Test.png";
            ImageName = "Player_Test.png";
        }

        public override void Update(GameTime gameTime)
        {
            //残像エフェクト関連
            trailParticles.Add(
                new TrailParticle()
                {
                    position = Coordinate,
                    timer = new Timer() { LimitTime = 1 }
                }
                    );
            trailParticles.ForEach(particle => particle.timer.Update());
            trailParticles.RemoveAll(particle => particle.timer.IsTime);

            base.Update(gameTime);
        }

        public override void UKill()
        {
            base_Stage.ResetStage();
            base.UKill();
        }

        public override void CalCollision(StageObj obj)
        {
            base.CalCollision(obj);
        }

        public override void Draw2(GameTime gameTime)
        {
            for (int i = 0; i < trailParticles.Count;)
            {
                spriteBatch.Draw(
                    trailImage.ImageT[0],
                    trailParticles[i].position,
                    null,
                    Color.Azure * trailParticles[i].timer.Rate,
                    0,
                    Vector2.Zero,
                    new Vector2(2, 2) * trailParticles[i].timer.Rate,
                    SpriteEffects.None,
                    0);
            }

            base.Draw2(gameTime);
        }
    }
}
