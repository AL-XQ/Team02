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
            AIs.Add("JumpEnemy", behaviourManager);

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("runaway", 0);
            behaviourManager.AddBehaviour("runaway", new RunAwayFromTarget(0.3f));
            behaviourManager.AddCondition("runaway", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs.Add("RunAwayEnemy", behaviourManager);

            behaviourManager = new BehaviourManager();
            behaviourManager.CreateBehaviour("movetowards", 0);
            behaviourManager.AddBehaviour("movetowards", new MoveTowardsTarget(0.3f));
            behaviourManager.AddCondition("movetowards", new DistanceBelowN(800));
            behaviourManager.CreateBehaviour("stop", 1);
            behaviourManager.AddBehaviour("stop", new StopMoving());
            behaviourManager.AddCondition("stop", new DistanceOverN(1200));
            AIs.Add("ChaseEnemy", behaviourManager);
        }
    }
}
