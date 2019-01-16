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
        private int attack = 50;
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
            sounds["death"] = SoundManage.GetSound("Player_Death.wav");
            base.LoadContent();
        }

        protected override void SetImage()
        {
            Motion.Images[Direction.Right][MotionState.Normal] = "player_normal_R.png";
            Motion.Images[Direction.Right][MotionState.Fall] = "player_fall_R.png";
            Motion.Images[Direction.Right][MotionState.Jump] = "player_jump_R.png";
            Motion.Images[Direction.Right][MotionState.Walk] = "player_walk_R.png";
            Motion.Images[Direction.Right][MotionState.Float] = "player_fall_R.png";
            Motion.Images[Direction.Left][MotionState.Normal] = "player_normal_L.png";
            Motion.Images[Direction.Left][MotionState.Fall] = "player_fall_L.png";
            Motion.Images[Direction.Left][MotionState.Jump] = "player_jump_L.png";
            Motion.Images[Direction.Left][MotionState.Walk] = "player_walk_L.png";
            Motion.Images[Direction.Left][MotionState.Float] = "player_fall_L.png";
            ImageName = "player_normal_R.png";
        }

        public override void Update(GameTime gameTime)
        {
            //残像エフェクト関連
            trailParticles.Add(
                new TrailParticle()
                {
                    position = ISpace.Center,
                    timer = new Timer(0.2f)
                });

            trailParticles.ForEach(particle => particle.timer.Update());
            trailParticles.RemoveAll(particle => particle.timer.IsTime);

            base.Update(gameTime);
        }

        public override void UKill()
        {
            sounds["death"].PlayE();
            base_Stage.ResetStage();
            base_Stage.MapCreator.ReSpawn();
            base.UKill();
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Enemy e)
            {
                var ve = Speed - e.Speed;
                if (Speed.LengthSquared() >= e.DamageSpeed * e.DamageSpeed)//ここはveじゃない理由は敵のスピードにわざと影響されないように
                {
                    e.Hp -= attack;
                    Speed -= ve * 0.8f;
                }
            }
            base.CalCollision(obj);
        }

        public override void Draw2(GameTime gameTime)
        {
            for (int i = 0; i < trailParticles.Count; i++)
            {
                spriteBatch.Draw(
                    trailImage.ImageT[0],
                    base_Stage.GetDrawLocation(trailParticles[i].position).ToVector2(),
                    null,
                    new Color(57, 141, 253) * MathHelper.Clamp(1 - trailParticles[i].timer.Rate, 0, 0.8f),
                    0,
                    new Vector2(16, 16),
                    new Vector2(2, 2) * (1 - trailParticles[i].timer.Rate),
                    SpriteEffects.None,
                    0);
            }

            base.Draw2(gameTime);
        }
    }
}
