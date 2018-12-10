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
        public BehaviourManager BehaviourManager { get => behaviourManager; set => behaviourManager = value; }

        public Enemy(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Add(this);
            MovePriority = 6;
        }

        public Enemy(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CharaManager.Add(this);
            MovePriority = 6;
        }

        public override void LoadContent()
        {
            Motion.Images[Direction.Right][MotionState.Normal] = "Enemy_Test.png";
            Motion.Images[Direction.Right][MotionState.Fall] = "Enemy_Test.png";
            Motion.Images[Direction.Right][MotionState.Jump] = "Enemy_Test.png";
            Motion.Images[Direction.Right][MotionState.Walk] = "Enemy_Test.png";
            Motion.Images[Direction.Right][MotionState.Float] = "Enemy_Test.png";
            Motion.Images[Direction.Left][MotionState.Normal] = "Enemy_Test.png";
            Motion.Images[Direction.Left][MotionState.Fall] = "Enemy_Test.png";
            Motion.Images[Direction.Left][MotionState.Jump] = "Enemy_Test.png";
            Motion.Images[Direction.Left][MotionState.Walk] = "Enemy_Test.png";
            Motion.Images[Direction.Left][MotionState.Float] = "Enemy_Test.png";
            base.LoadContent();
        }

        protected override void OffSet()
        {
            RenderCoo_Offset = -size.ToVector2() * new Vector2(0.25f, 0.25f);
            RenderSize_Offset = size.ToVector2() * new Vector2(0.5f, 0.5f);
        }

        protected override void SetImage()
        {
            ImageName = "messagebox.png";
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (behaviourManager != null)
            {
                behaviourManager.Update();
            }
            base.Update(gameTime);
        }
    }
}
