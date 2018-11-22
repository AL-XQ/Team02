using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;

namespace Team02.Scene.UI
{
    public class MainMenu : UIWindow
    {
        private AnimeButton start;
        public MainMenu(BaseDisplay parent) : base(parent)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            Size = parent.Size / 3;
            start = new AnimeButton(this);
            start.Size = size / 3;
            start.Location = new Microsoft.Xna.Framework.Point(100, 100);
            base.PreLoadContent();
        }


    }
}
