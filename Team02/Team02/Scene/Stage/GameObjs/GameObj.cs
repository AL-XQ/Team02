using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;

using InfinityGame.Device;
using Microsoft.Xna.Framework;

namespace Team02.Scene.Stage.GameObjs
{
    public abstract class GameObj : StageObj
    {
        private string imageName = "";
        protected Base_Stage base_Stage;

        public string ImageName { get => imageName; set => SetImageName(value); }
        public GameObj(BaseDisplay aParent) : base(aParent)
        {
            base_Stage = (Base_Stage)aParent;
        }

        public GameObj(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator.Stage)
        {
            base_Stage = mapCreator.Stage;
        }


        public GameObj(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            base_Stage = (Base_Stage)aParent;
        }

        protected virtual void SetImageName(string value)
        {
            imageName = value;
            if (imageName == "")
            {
                image = null;
                return;
            }
            image = ImageManage.GetSImage(imageName);
        }

        public override void PreLoadContent()
        {
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            SetImage();
            OffSet();
            base.LoadContent();
        }

        protected virtual void SetImage()
        {
            
        }

        protected virtual void OffSet()
        {

        }

        public void Create()
        {
            PreLoadContent();
            LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
