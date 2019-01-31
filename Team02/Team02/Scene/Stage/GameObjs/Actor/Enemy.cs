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
            _Damage += Damageeffect;
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
            ImageName = "Enemy.png";
            Motion.Images[Direction.Right][MotionState.Normal] = ImageName;
            Motion.Images[Direction.Right][MotionState.Fall] = ImageName;
            Motion.Images[Direction.Right][MotionState.Jump] = ImageName;
            Motion.Images[Direction.Right][MotionState.Walk] = ImageName;
            Motion.Images[Direction.Right][MotionState.Float] = ImageName;
            Motion.Images[Direction.Left][MotionState.Normal] = ImageName;
            Motion.Images[Direction.Left][MotionState.Fall] = ImageName;
            Motion.Images[Direction.Left][MotionState.Jump] = ImageName;
            Motion.Images[Direction.Left][MotionState.Walk] = ImageName;
            Motion.Images[Direction.Left][MotionState.Float] = ImageName;

        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //if (Vector2.Distance(Coordinate, Stage.CameraCenter) > 2000)
            //    return;
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
            if (Hp <= 0)
            {
                var ef = Effect.CreateEffect(this, "enemy_died");
                ef.Time = 32;
                ef.Size = (size + Size.Parse(RenderCoo_Offset.ToPoint())) * 5;
                ef.Offset = -(ef.Size / 2.75f).ToVector2();
                ef.Origin = ef.Size.ToVector2() / 2;
            }
        }
        private void Damageeffect()
        {
            if (Hp > 0)
            {
                var def = Effect.CreateEffect(this, "enemy_damage");
                def.Time = 30;
                def.Size = (size + Size.Parse(RenderCoo_Offset.ToPoint())) * 7 / 2;
                def.Offset = -(def.Size / 3).ToVector2();
                def.Origin = def.Size.ToVector2() / 2;
                _Update -= Damageeffect;
            }
        }
    }
}
