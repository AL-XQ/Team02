using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Actor.AI;
using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Enemy : Chara
    {
        private BehaviourManager behaviourManager;

        public Enemy(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Add(this);
        }

        public override void LoadContent()
        {
            Motion.Images[Direction.Right][MotionState.Normal] = "Player_Test.png";
            Motion.Images[Direction.Right][MotionState.Fall] = "state_test_fall.png";
            Motion.Images[Direction.Right][MotionState.Jump] = "state_test_jump.png";
            Motion.Images[Direction.Right][MotionState.Walk] = "state_test_walk.png";
            Motion.Images[Direction.Right][MotionState.Float] = "Player_Test.png";
            Motion.Images[Direction.Left][MotionState.Normal] = "Player_Test.png";
            Motion.Images[Direction.Left][MotionState.Fall] = "state_test_fall.png";
            Motion.Images[Direction.Left][MotionState.Jump] = "state_test_jump.png";
            Motion.Images[Direction.Left][MotionState.Walk] = "state_test_walk.png";
            Motion.Images[Direction.Left][MotionState.Float] = "Player_Test.png";
            base.LoadContent();
        }

        protected override void SetImage()
        {
            ImageName = "messagebox.png";
        }

        public override void PreLoadContent()
        {
            behaviourManager = new BehaviourManager(this, CharaManager.Hero);
            behaviourManager.CreateBehaviour("rightMove", 0);
            behaviourManager.AddBehaviour("rightMove", new StraightMove(new Vector2(1, 0)));
            behaviourManager.AddCondition("rightMove", new DistanceBelowN(50));

            behaviourManager.CreateBehaviour("leftMove", 1);
            behaviourManager.AddBehaviour("leftMove", new StraightMove(new Vector2(-1, 0)));
            behaviourManager.AddCondition("leftMove", new DistanceOverN(100));
            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            behaviourManager.Update();
            base.Update(gameTime);
        }
    }
}
