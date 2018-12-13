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
        
        public Player Player { get => player; }
        public LineUI LineUI { get => lineUI; }

        public EnemyCountUI EnemyCountUI { get => enemyCntUI; }

        public PlayScene(string aName, GraphicsDevice aGraphicsDevice, BaseDisplay aParent, GameRun aGameRun) : base(aName, aGraphicsDevice, aParent, aGameRun)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void PreLoadContent()
        {
            player = new Player(this);
            backMenu = new BackMenu(this);
            lineUI = new LineUI(this);
            enemyCntUI = new EnemyCountUI(this);
            new Stage01(this, "stage01");
            ShowStage = stages["stage01"];
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
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
            Console.WriteLine(((Base_Stage)ShowStage).CharaManager.Enemys.Count);
            EnemyCountUI.EnemyCnt = ((Base_Stage)ShowStage).CharaManager.Enemys.Count;

            base.Update(gameTime);
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
