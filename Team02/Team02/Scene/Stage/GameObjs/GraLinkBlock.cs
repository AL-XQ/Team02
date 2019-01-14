using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.API;
using Team02.Device;

namespace Team02.Scene.Stage.GameObjs
{
    public class GraLinkBlock : Block, IGraLink
    {
        private IGraChange graObj;
        private string target;
        public GraLinkBlock(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        public GraLinkBlock(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
            if (args.ContainsKey("other"))
            {
                var otherArgs = TextReader.Read((string)args["other"]);
                if (otherArgs.ContainsKey("target"))
                    Target = otherArgs["target"];
            }
        }

        public IGraChange GraObj { get => graObj; set => graObj = value; }
        public string Target { get => target; set => SetTarget(value); }

        private void SetTarget(string value)
        {
            target = value;
            _Update += CheckTarget;
        }

        private void CheckTarget()
        {
            if (base_Stage.stageObjs.ContainsKey(target))
            {
                graObj = (IGraChange)base_Stage.stageObjs[target];
                _Update -= CheckTarget;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
