using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Def;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;
using Team02.Scene.Stage.GameObjs.Actor.AI;
using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

using Team02.Device;
namespace Team02.Scene.Stage
{
    public class Stage01 : Base_Stage
    {
        private Enemy testenemy;
        public Stage01(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            EndOfRightDown = new Vector2(2000, 2000);
        }

        public override void PreLoadContent()
        {
            Player.CameraCenter = IGConfig.screen.ToVector2() / 2;

            Map = "test";


            //Test
            testenemy = new Enemy(this, "enemy");
            testenemy.Coordinate = new Vector2(800, 400);
            testenemy.Size = new Size(64, 64);
            //Test


            base.PreLoadContent();


            //Test
            var behaviourManager = new BehaviourManager(testenemy, CharaManager.Hero);

            behaviourManager.CreateBehaviour("runaway", 0);
            behaviourManager.AddBehaviour("runaway", new RunAwayFromTarget(0.2f));
            behaviourManager.AddBehaviour("runaway", new Fly());
            behaviourManager.AddCondition("runaway", new DistanceBelowN(500));

            behaviourManager.CreateBehaviour("stopmoving", 1);
            behaviourManager.AddBehaviour("stopmoving", new StopMoving());
            behaviourManager.AddCondition("stopmoving", new DistanceOverN(1200));
            testenemy.BehaviourManager = behaviourManager;
            //Test
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
