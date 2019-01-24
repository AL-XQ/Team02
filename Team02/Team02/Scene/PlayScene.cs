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
        private GameOver gameOver;
        private GameClear gameClear;
        private StageFade stageFade;
        public int nowStage = 0;
        private List<string> stageOrder = new List<string>();
        private List<BossStage> bossStages = new List<BossStage>();
        private bool running = false;

        public Player Player { get => player; }
        public LineUI LineUI { get => lineUI; }

        public EnemyCountUI EnemyCountUI { get => enemyCntUI; }
        public TimerUI TimerUI { get => timerUI; }
        public int NowStage { get => nowStage; set => SetNowStage(value); }
        public BackMenu BackMenu { get => backMenu; }
        public bool Running { get => running; }

        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {

        }

        private void SetNowStage(int value)
        {
            if (value >= stageOrder.Count)
                nowStage = 0;
            else
                nowStage = value;
            SetShowStage(stageOrder[nowStage]);
        }

        public override void Initialize()
        {
            player.Initialize();
            base.Initialize();
            SetShowStage(stageOrder[nowStage]);
            enemyCntUI.MaxEnemyCnt = ((Base_Stage)ShowStage).CharaManager.Enemys.Count;
        }

        public override void PreLoadContent()
        {
            player = new Player(this);
            backMenu = new BackMenu(this);
            lineUI = new LineUI(this);
            enemyCntUI = new EnemyCountUI(this);
            timerUI = new TimerUI(this);
            gameOver = new GameOver(this);
            gameClear = new GameClear(this);
            var m1 = new TutorialStage(this, "stage01");
            stageFade = new StageFade(this);
            var m1 = new Base_Stage(this, "stage01");
            m1.Map = "map01";
            m1.StageTime = 6000;
            var m2 = new Base_Stage(this, "stage02");
            m2.Map = "map02";
            m2.StageTime = 240;
            var m3 = new Base_Stage(this, "stage03");
            m3.Map = "map03";
            m3.StageTime = 30;
            bossStages.Add(new BossStage1(this, "bossstage1"));
            bossStages[0].Map = "map04";
            stageOrder.AddRange(new string[] { "stage01", "stage02", "stage03", "bossstage1" });
            nowStage = 0;
            base.PreLoadContent();
        }

        public void SetShowStage(string stageName)
        {
            var bs = (Base_Stage)stages[stageName];
            if (ShowStage != null)
                ShowStage.ClearStage();
            ShowStage = bs;
            ShowStage.Initialize();
            if (sounds["bgm"] != null && sounds["bgm"] != bs.sounds["bgm"])
                sounds["bgm"].Stop();
            if (sounds["bgm"] != null || sounds["bgm"] != bs.sounds["bgm"])
            {
                sounds["bgm"] = bs.sounds["bgm"];
                if (IsRun)
                    sounds["bgm"].Play();
            }
            ReadStageTime();
            player.Chara = bs.CharaManager.Hero;
        }

        public void ReadStageTime()
        {
            var bs = (Base_Stage)ShowStage;
            timerUI.SetTime(bs.StageTime);
        }

        public override void LoadContent()
        {
            sounds["bgm"] = null;
            GraChanger.ControlC = ImageManage.GetSImage("control_main.png");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            running = true;
            player.Update(gameTime);
            if ((GameKeyboard.GetKeyTrigger(Keys.Escape) || IGGamePad.GetKeyTrigger(PlayerIndex.One, Buttons.Back)))
            {
                backMenu.Visible = !backMenu.Visible;
                backMenu.SetFocus();
            }

            if (backMenu.Visible || gameOver.Visible || gameClear.Visible || stageFade.Visible)
            {
                running = false;
                backMenu.Update(gameTime);
                gameOver.Update(gameTime);
                gameClear.Update(gameTime);
                stageFade.Update(gameTime);
                return;
            }
            if (timerUI.IsTime)
            {
                gameOver.Visible = true;
                running = false;
                return;
            }
            if (enemyCntUI.IsClear)
            {
                if (nowStage < stageOrder.Count - 1)
                {
                    var st = nowStage + 1;
                    stageFade.D_Text = "Stage" + st.ToString();
                    stageFade.ChangeTo(st);
                }
                else
                {
                    gameClear.Visible = true;
                }
                running = false;
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
