using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Element;
using InfinityGame.Def;
using Microsoft.Xna.Framework;

using Team02.Scene.Stage.GameObjs;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage
{
    public abstract class Base_Stage : BaseStage
    {
        private PlayScene playScene;
        private StageMap stageMap;
        private CharaManager charaManager = new CharaManager();
        private Vector2 defGra;
        public Player Player { get => playScene.Player; }
        public PlayScene PlayScene { get => playScene; }
        public CharaManager CharaManager { get => charaManager; }
        public Vector2 DefGra { get => defGra; set => defGra = value; }

        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            playScene = (PlayScene)parent;
        }

        public override void Initialize()
        {
            defGra = new Vector2(0, 0.5f);
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            stageMap = new StageMap(this);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        /// <summary>
        /// ステージ座標によってDrawする座標を獲得する
        /// </summary>
        /// <param name="Coo"></param>
        public Vector2 GetDrawLocation(Vector2 Coo)
        {
            return (Coo - CameraLocation) * CameraScale;
        }
    }
}
