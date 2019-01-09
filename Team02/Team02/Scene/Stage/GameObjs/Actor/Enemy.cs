using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
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
            if (args.ContainsKey("ai"))
            {
                behaviourManager = AIPackage.AIs[(string)args["ai"]].Copy();
                behaviourManager.User = this;
                behaviourManager.Target = CharaManager.Hero;
            }
        }

        public override void Initialize()
        {
            DamageSpeed = 19f;
            base.Initialize();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void OffSet()
        {
            RenderCoo_Offset = -size.ToVector2() * new Vector2(0.25f, 0.25f);
            RenderSize_Offset = size.ToVector2() * new Vector2(0.5f, 0.5f);
        }

        protected override void SetImage()
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

        public override void CalCollision(StageObj obj)
        {
            if (obj is Enemy enemy)
            {
                Vector2 a = Speed * 0.5f;
                enemy.Speed += a;
                Speed -= a;
            }
            base.CalCollision(obj);
        }
    }
}
