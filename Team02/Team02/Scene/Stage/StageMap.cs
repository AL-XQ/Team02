using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene.Stage
{
    public class StageMap
    {
        private Base_Stage base_Stage;
        private List<BlockGroup> blockGroups = new List<BlockGroup>();

        public List<BlockGroup> BlockGroups { get => blockGroups; }

        public StageMap(Base_Stage base_Stage)
        {
            this.base_Stage = base_Stage;
            BlockGroup.SetOffI();
        }
    }
}
