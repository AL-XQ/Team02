using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Hero : Chara
    {
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
    }
}
