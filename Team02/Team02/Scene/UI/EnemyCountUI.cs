using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using InfinityGame.Element;
using InfinityGame.Device;
using InfinityGame.Device.MouseManage;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene.UI
{
    public class EnemyCountUI : Label
    {
        private PlayScene playScene;
        private int enemyCnt;

        public int EnemyCnt { get => enemyCnt; set => enemyCnt = value; }

        public EnemyCountUI(BaseDisplay parent) : base(parent)
        {
            playScene = (PlayScene)parent;
            enemyCnt = 0;
        }

        public override void PreLoadContent()
        {
            location = Point.Zero;
            BDText.ForeColor = System.Drawing.Color.Red;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Text = "残りエネミー：" + enemyCnt;
            base.Update(gameTime);
        }
    }
}
