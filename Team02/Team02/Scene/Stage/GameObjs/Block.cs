using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;

using Team02.Scene.Stage.GameObjs.Actor;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team02.Scene.Stage.GameObjs
{
    public class Block : GameObj
    {
        private string imageName = "";
        private float coeff = 0.05f;
        public string ImageName { get => imageName; set => SetImageName(value); }
        public float Coeff { get => coeff; set => coeff = value; }

        public Block(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            IsCrimp = true;
            BeMove = false;
            MovePriority = 10;
        }

        protected virtual void SetImageName(string value)
        {
            imageName = value;
            image = ImageManage.GetSImage(imageName);
        }

        protected virtual void SetImage()
        {
            imageName = "Block_Test.png";
        }

        public override void PreLoadContent()
        {
            RenderCoo_Offset = -size.ToVector2() / 2;
            RenderSize_Offset = size.ToVector2();
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            SetImage();
            image = ImageManage.GetSImage(imageName);
            base.LoadContent();

        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara c)
            {
                c.DisSpeed(coeff);
                c.Strut();
            }
            base.CalCollision(obj);
        }
    }
}