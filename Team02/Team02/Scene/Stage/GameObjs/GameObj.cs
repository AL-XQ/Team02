using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage.StageObject;

using InfinityGame.Device;
using Microsoft.Xna.Framework;
using InfinityGame;
using Team02.Scene.Stage.GameObjs.API;
using InfinityGame.Element;

namespace Team02.Scene.Stage.GameObjs
{
    public abstract class GameObj : StageObj
    {
        protected D_Void _Update;
        protected D_Void _LastUpdate;

        private string imageName = "";
        protected Base_Stage base_Stage;

        public string ImageName { get => imageName; set => SetImageName(value); }
        public GameObj(BaseDisplay aParent) : base(aParent)
        {
            base_Stage = (Base_Stage)aParent;
        }

        public GameObj(MapCreator mapCreator, Dictionary<string, object> args) : base(mapCreator.Stage, args.ContainsKey("name") ? (string)args["name"] : "Null")
        {
            base_Stage = mapCreator.Stage;
        }


        public GameObj(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            base_Stage = (Base_Stage)aParent;
        }

        public override bool Equals(object obj)
        {
            return SCID == ((GameObj)obj).SCID;
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
            _Update?.Invoke();
            base.Update(gameTime);
            _LastUpdate?.Invoke();
        }

        public virtual bool CheckIForceOn(IForce c)
        {
            if (c.Gra != Vector2.Zero)
            {
                ISpace check = c.ISpace.Copy();
                if (ISpace.Intersects(check))
                {
                    var esc = ISpace.Escape(check);
                    check.Location += esc;
                }
                check.Location += c.Gra;
                if (this is IForce tf)
                {
                    check.Location += tf.Gra;
                }
                if (ISpace.Intersects(check))
                {
                    var esc = ISpace.Escape(check);
                    if (esc != Vector2.Zero)
                        return true;
                }
            }
            return false;
        }
    }
}
