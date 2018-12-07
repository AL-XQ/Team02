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

using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs;

namespace Team02.Scene
{
    public class TestUI : Button
    {
        private PlayScene playScene;
        private Label tl;

        public TestUI(BaseDisplay aParent) : base(aParent)
        {
            Color = Color.Transparent;
            playScene = (PlayScene)aParent;
            visible = false;
        }

        public override void PreLoadContent()
        {
            tl = new Label(this);
            tl.Location = new Point(200, 200);
            tl.Text = GetText("aaa");
            tl.BDText.ForeColor = System.Drawing.Color.Red;
            Location = new Point(100, 100);
            size = new Size(500, 500);
            Click += BT_Click;
            Enter += BT_Enter;
            //LeftDown += BT_Enter;
            LeftTrigger += BT_Enter;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("button03");
            sounds["click"] = SoundManage.GetSound("click.wav");
            sounds["enter"] = SoundManage.GetSound("enter.wav");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void BT_Click(object sender, EventArgs e)
        {
            sounds["click"].PlayE();
        }

        private void BT_Enter(object sender, EventArgs e)
        {
            sounds["enter"].PlayE();
        }
    }
}
