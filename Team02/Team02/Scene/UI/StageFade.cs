using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage;
using InfinityGame.Element;
using InfinityGame.Device;

using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.UI
{
    public class StageFade : Panel
    {
        private Label lable;
        private int runTime = 120;
        private int time = 0;
        private float fadeUnity = 0;
        private float fadeImageUnity = 0;
        private PlayScene playScene;
        private string d_Text = "";
        private string d_Text1 = "";
        private int target;
        private SImage showImage;
        private Texture2D black;
        private int showImageRunTIme = 60;
        private int showImageTime = 0;
        private bool showBlack = false;
        public int Target { get => target; set => target = value; }
        public string D_Text { get => d_Text; set => d_Text = value; }

        public StageFade(BaseDisplay aParent) : base(aParent)
        {
            Visible = false;
            Refract = 0;
            playScene = (PlayScene)parent;
        }

        public void ChangeTo(int stage)
        {
            target = stage;
            visible = true;
            fadeUnity = 2f / runTime;
            fadeImageUnity = 2f / showImageRunTIme;
            lable.Text = d_Text;
            lable.Location = ((size - lable.Size) / 2).ToPoint();
            image = showImage;
            lable.Visible = false;
        }

        public override void PreLoadContent()
        {
            lable = new Label(this);
            lable.TextSize = 72f;
            lable.Color = Color.BlueViolet;
            size = parent.Size;
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            showImage = ImageManage.GetSImage("CLEAR.png");
            black = new Texture2D(GraphicsDevice, 1, 1);
            black.SetData(new Color[] { Color.Black });
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Fade();
            base.Update(gameTime);
        }

        private void Fade()
        {
            if (visible)
            {
                if (showImageTime > showImageRunTIme)
                {
                    if (time > runTime)
                    {
                        visible = false;
                        time = 0;
                        showImageTime = 0;
                        image = showImage;
                    }
                    else if (time > runTime / 2)
                    {
                        Refract -= fadeUnity;
                    }
                    else if (time == runTime / 2)
                    {
                        showBlack = false;
                        playScene.nowStage = target;
                        playScene.Initialize();
                    }
                    else
                    {
                        Refract += fadeUnity;
                    }
                    time++;
                    return;
                }
                else if (showImageTime == showImageRunTIme)
                {
                    image = null;
                    lable.Visible = true;
                    Refract += fadeImageUnity;
                }
                else if (showImageTime > showImageRunTIme / 2)
                {
                    Refract -= fadeImageUnity;
                }
                else if (showImageTime == showImageRunTIme / 2)
                {
                    showBlack = true;
                }
                else
                {
                    Refract += fadeImageUnity;
                }
                showImageTime++;
            }
        }

        public override void Draw1(GameTime gameTime)
        {
            if (showBlack)
                spriteBatch.Draw(black, new Rectangle(location, size.ToPoint()), Color.White);
            base.Draw1(gameTime);
        }
    }
}
