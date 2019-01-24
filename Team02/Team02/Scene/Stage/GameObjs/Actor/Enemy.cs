﻿using System;
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
using InfinityGame.Element;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Enemy : Chara
    {
        private BehaviourManager behaviourManager;
        public BehaviourManager BehaviourManager { get => behaviourManager; set => behaviourManager = value; }

        public Enemy(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            CharaManager.Add(this);
        }

        public Enemy(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            CharaManager.Add(this);
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
            _Damage += Deatheffect;
            base.Initialize();
        }

        public override void LoadContent()
        {
            sounds["death"] = SoundManage.GetSound("Enemy_Death.wav");
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
            if (!(this is HideEnemy) && obj is Hero h)
            {
                h.Hp -= 0.1f;
            }
            base.CalCollision(obj);
        }

        public override void UKill()
        {
            base.UKill();
        }

        private void Deatheffect()
        {
            if(Hp<=0)
            {
                Console.WriteLine(true);
                var ef = Effect.CreateEffect(this, "enemy_died");
                ef.Time = 33;
                ef.Size = (size + Size.Parse(RenderCoo_Offset.ToPoint())) * 20;
                ef.Origin = ef.Size.ToVector2() / 2;
            }
        }
    }
}
