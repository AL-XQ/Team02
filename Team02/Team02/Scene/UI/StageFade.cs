﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;
using Microsoft.Xna.Framework;
using Team02.Scene.Stage;

namespace Team02.Scene.UI
{
    public class StageFade : Panel
    {
        private Label lable;
        private int runTime = 120;
        private int time = 0;
        private float fadeUnity = 0;
        private PlayScene playScene;
        private string d_Text = "";
        private int target;
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
            lable.Text = d_Text;
            lable.Location = ((size - lable.Size) / 2).ToPoint();
        }

        public override void PreLoadContent()
        {
            lable = new Label(this);
            lable.TextSize = 72f;
            lable.Color = Color.BlueViolet;
            size = parent.Size;
            base.PreLoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (visible)
            {
                if (time > runTime)
                {
                    visible = false;
                    time = 0;
                }
                else if (time > runTime / 2)
                {
                    Refract -= fadeUnity;
                }
                else if (time == runTime / 2)
                {
                    playScene.nowStage = target;
                    playScene.Initialize();
                }
                else
                {
                    Refract += fadeUnity;
                }
                time++;
            }
            base.Update(gameTime);
        }
    }
}
