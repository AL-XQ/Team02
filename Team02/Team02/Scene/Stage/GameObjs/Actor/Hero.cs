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
