using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Hero : Chara
    {
        public Hero(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Hero = this;
        }

        public override void LoadContent()
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
            base.LoadContent();
        }

        protected override void SetImage()
        {
            ImageName = "Player_Test.png";
        }
    }
}
