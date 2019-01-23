using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public class Effect : GameObj
    {
        private GameObj target;
        private int time = -1;

        public GameObj Target { get => target; set => SetTarget(value); }
        public int Time { get => time; set => time = value; }

        public Effect(BaseDisplay aParent) : base(aParent)
        {
        }

        public Effect(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator, args)
        {
        }

        public Effect(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
        }

        private void SetTarget(GameObj value)
        {
            target = value;
        }

        public static Effect CreateEffect(GameObj target, string imageName)
        {
            var ef = new Effect(target.Stage);
            ef.Target = target;
            ef.ImageName = imageName;
            ef.Create();
            return ef;
        }

        public static Effect CreateEffect(Base_Stage stage, string imageName)
        {
            var ef = new Effect(stage);
            ef.ImageName = imageName;
            ef.Create();
            return ef;
        }

        public override void Update(GameTime gameTime)
        {
            if (time > 0)
                time--;
            else if (time == 0)
                Kill();
            base.Update(gameTime);
        }
    }
}
