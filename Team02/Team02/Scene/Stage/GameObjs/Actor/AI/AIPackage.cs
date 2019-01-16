using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Scene.Stage.GameObjs.Actor.AI.Behaviour;
using Team02.Scene.Stage.GameObjs.Actor.AI.Condition;

namespace Team02.Scene.Stage.GameObjs.Actor.AI
{
    public class AIPackage
    {
        public static Dictionary<string, BehaviourManager> AIs = new Dictionary<string, BehaviourManager>();

        public static void Create()
        {
            BehaviourManager behaviourManager = new BehaviourManager();

            behaviourManager.CreateBehaviour("jump", 0);
            behaviourManager.AddBehaviour("jump", new Jump(10));
            behaviourManager.AddCondition("jump", new DistanceBelowN(500));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs["JumpEnemy"] = behaviourManager;

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("runaway", 0);
            behaviourManager.AddBehaviour("runaway", new RunAwayFromTarget(0.3f));
            behaviourManager.AddCondition("runaway", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs["RunAwayEnemy"] = behaviourManager;

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("movetowards", 0);
            behaviourManager.AddBehaviour("movetowards", new MoveTowardsTarget(0.3f));
            behaviourManager.AddCondition("movetowards", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs["ChaseEnemy"] = behaviourManager;

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("flyChase", 0);
            behaviourManager.AddBehaviour("flyChase", new BehaviourBase[] { new Fly(), new MoveTowardsTarget(0.2f) });
            behaviourManager.AddCondition("flyChase", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving(flying:true));
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs["FlyEnemy"] = behaviourManager;

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("jumpChase", 0);
            behaviourManager.AddBehaviour("jumpChase", new BehaviourBase[] { new Jump(5), new MoveTowardsTarget(0.1f) });
            behaviourManager.AddCondition("jumpChase", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs["JumpChaseEnemy"] = behaviourManager;

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("chaseTarget", 0);
            behaviourManager.AddBehaviour("chaseTarget", new MoveTowardsTarget(0.3f));
            behaviourManager.AddCondition("chaseTarget", new DistanceBelowN(400));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new BehaviourBase[] { new StopMoving(), new Jump(10) });
            behaviourManager.AddCondition("stop", new DistanceOverN(600));
            AIs["IdleJumpEnemy"] = behaviourManager;
        }
    }
}
