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
using Team02.Device;

namespace Team02.Scene.Stage
{
    public abstract class Base_Stage : BaseStage
    {
        private PlayScene playScene;
        private MapCreator mapCreator;
        private CharaManager charaManager = new CharaManager();
        private Vector2 defGra;
        private string map;
        private List<GraChanger> graChangers = new List<GraChanger>();
        private GraChanger nowChanger;
        private bool reset = false;
        public Player Player { get => playScene.Player; }
        public PlayScene PlayScene { get => playScene; }
        public CharaManager CharaManager { get => charaManager; }
        public Vector2 DefGra { get => defGra; set => defGra = value; }
        public MapCreator MapCreator { get => mapCreator; }
        public string Map { get => map; set => map = value; }
        public List<GraChanger> GraChangers { get => graChangers; }
        public GraChanger NowChanger { get => nowChanger; set => SetNowChanger(value); }

        public Base_Stage(BaseDisplay aParent, string aName) : base(aParent, aName)
        {
            playScene = (PlayScene)parent;
        }

        private void SetNowChanger(GraChanger value)
        {
            nowChanger = value;
            playScene.LineUI.IsShoot = (nowChanger == null);
        }

        public void ResetStage()
        {
            reset = true;
        }

        public override void Initialize()
        {
            defGra = new Vector2(0, 0.5f);
            ClearStage();
            charaManager.Initialize();
            mapCreator.MapRead(BinaryReader.ReadMap(map));
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            mapCreator = new MapCreator(this);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            GraChangerUpdate(gameTime);
            MapCreator.Update();
            base.Update(gameTime);
            AfterUpdate();
        }

        public void AfterUpdate()
        {
            if (reset)
            {
                Initialize();
                reset = false;
            }
        }

        private void GraChangerUpdate(GameTime gameTime)
        {
            if (nowChanger != null)
                nowChanger.Update(gameTime);
            for (int i = 0; i < GraChangers.Count;)
            {
                if (graChangers[i].IsOver)
                {
                    graChangers.RemoveAt(i);
                    continue;
                }
                graChangers[i].Update(gameTime);
                i++;
            }
        }

        /// <summary>
        /// ステージ座標によってDrawする座標を獲得する
        /// </summary>
        /// <param name="Coo"></param>
        public Point GetDrawLocation(Vector2 Coo)
        {
            return ((Coo - CameraLocation) * CameraScale).ToPoint();
        }

        /// <summary>
        /// スクリーンの座標をステージの座標に変換
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector2 GetStageCoo(Vector2 point)
        {
            return point / CameraScale + CameraLocation;
        }
    }
}
