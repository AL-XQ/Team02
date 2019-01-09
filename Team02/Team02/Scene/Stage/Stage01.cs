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
        private HiddenBlock testbutton;
        public Stage01(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            EndOfRightDown = new Vector2(2000000, 2000000);
        }

        public override void Initialize()
        {
            Player.CameraCenter = IGConfig.screen.ToVector2() / 2;
            base.Initialize();
            testbutton = new HiddenBlock(this, "adfa")
            {
                UnitedSize = new Size(5, 5),
                Coordinate = new Vector2(500, 500),
            };

            testbutton.Create();
        }

        public override void PreLoadContent()
        {
            Map = "map01";


            //Test
            testenemy = new Enemy(this, "enemy");
            testenemy.Coordinate = new Vector2(800, 400);
            testenemy.Size = new Size(64, 64);

            //Test


            base.PreLoadContent();


            //Test
            var behaviourManager = new BehaviourManager();

            behaviourManager.CreateBehaviour("runaway", 0);
            behaviourManager.AddBehaviour("runaway", new RunAwayFromTarget(0.2f));
            behaviourManager.AddBehaviour("runaway", new Fly());
            behaviourManager.AddCondition("runaway", new DistanceBelowN(500));

            behaviourManager.CreateBehaviour("stopmoving", 1);
            behaviourManager.AddBehaviour("stopmoving", new StopMoving());
            behaviourManager.AddCondition("stopmoving", new DistanceOverN(1200));
            behaviourManager.User = testenemy;
            behaviourManager.Target = CharaManager.Hero;
            testenemy.BehaviourManager = behaviourManager;
            //Test
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
