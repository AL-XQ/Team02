using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Device;
using Microsoft.Xna.Framework;
using InfinityGame.Stage.StageObject;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class Chara : GameObj
    {
        private int hp;
        public Chara(BaseDisplay aParent, string aName) : base(aParent, aName)
        {

        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void PreLoadContent()
        {
            Size = new InfinityGame.Element.Size(200, 200);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            image = ImageManage.GetSImage("chat.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (hp <= 0)
            {
                Kill();
            }
            base.Update(gameTime);
        }

        public override void CalCollision(StageObj obj)
        {
            if (obj is Chara test)
            {
                ChangeStage(Stage.StageScene.stages["aa"]);
            }
            base.CalCollision(obj);
        }
    }
}
