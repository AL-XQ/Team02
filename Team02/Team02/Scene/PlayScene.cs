using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Team02.Scene.Stage;
using Team02.Scene.Stage.GameObjs;
using Team02.Scene.UI;

using InfinityGame.Device;
using InfinityGame.UI.UIContent;
using InfinityGame.Device.MouseManage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Device.KeyboardManage;
using Microsoft.Xna.Framework.Input;
using Team02.Scene.Stage.GameObjs.Actor.AI;

namespace Team02.Scene
{
    public class PlayScene : StageScene
    {
        private Player player;
        private BackMenu backMenu;
        private LineUI lineUI;
        private EnemyCountUI enemyCntUI;
        private TimerUI timerUI;
        private int nowStage = 0;
        private List<string> stageOrder = new List<string>();
        private List<BossStage> bossStages = new List<BossStage>();

        public Player Player { get => player; }
        public LineUI LineUI { get => lineUI; }

        public EnemyCountUI EnemyCountUI { get => enemyCntUI; }
        public TimerUI TimerUI { get => timerUI; }
        public int NowStage { get => nowStage; set => SetNowStage(value); }

        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        private void SetNowStage(int value)
        {
            nowStage = value;
            SetShowStage(stageOrder[nowStage]);
        }

        public override void Initialize()
        {
            player.Initialize();
            base.Initialize();
            SetShowStage(stageOrder[nowStage]);
        }

        public override void PreLoadContent()
        {
            player = new Player(this);
            backMenu = new BackMenu(this);
            lineUI = new LineUI(this);
            enemyCntUI = new EnemyCountUI(this);
            timerUI = new TimerUI(this);
            var m1 = new Base_Stage(this, "stage01");
            m1.Map = "map01";
            var m2 = new Base_Stage(this, "stage02");
            m2.Map = "map02";
            bossStages.Add(new BossStage1(this, "bossstage1"));
            bossStages[0].Map = "map04";
            stageOrder.AddRange(new string[] { "stage01", "stage02", "bossstage1", "bossstage1" });
            nowStage = 0;
            base.PreLoadContent();
        }

        public void SetShowStage(string stageName)
        {
            var bs = (Base_Stage)stages[stageName];
            ShowStage = bs;
            if (sounds["bgm"] != null)
                sounds["bgm"].Stop();
            sounds["bgm"] = bs.sounds["bgm"];
            sounds["bgm"].Play();
            player.Chara = bs.CharaManager.Hero;
        }
        public override void LoadContent()
        {
            sounds["bgm"] = null;
            GraChanger.ControlC = ImageManage.GetSImage("control_test.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if ((GameKeyboard.GetKeyTrigger(Keys.Escape) || IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back)))
            {
                backMenu.Visible = !backMenu.Visible;
                backMenu.SetFocus();
            }

            if (backMenu.Visible)
            {
                backMenu.Update(gameTime);
                return;
            }
            if (timerUI.IsTime)
            {
                var sc = GameRun.Instance.scenes;
                sc["play"].IsRun = false;
                sc["title"].IsRun = true;
                sc["play"].Initialize();
                return;
            }
            if (enemyCntUI.IsClear)
            {
                if (nowStage < stageOrder.Count - 1)
                {
                    nowStage++;
                    Initialize();
                }
                else
                {
                    //クリア
                    var sc = GameRun.Instance.scenes;
                    sc["play"].IsRun = false;
                    sc["title"].IsRun = true;
                    sc["play"].Initialize();
                }
                return;
            }

            player.Update();
            base.Update(gameTime);
            player.AfterUpdate();
        }

        /// <summary>
        /// ステージ座標によってDrawする座標を獲得する
        /// </summary>
        /// <param name="Coo"></param>
        public Point GetDrawLocation(Vector2 Coo)
        {
            return ((Base_Stage)ShowStage).GetDrawLocation(Coo);
        }
        /// <summary>
        /// スクリーンの座標をステージの座標に変換
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector2 GetStageCoo(Vector2 point)
        {
            return ((Base_Stage)ShowStage).GetStageCoo(point);
        }

    }
}
