// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using InfinityGame.Lang;
using InfinityGame.Scene;
using InfinityGame.Device;
using InfinityGame.Def;
using InfinityGame;
using System.IO;
using System;
using System.Threading;
using InfinityGame.Device.WindowsScreen;
using InfinityGame.Device.KeyboardManage;
using Team02.Scene;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace Team02
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        //private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト  //このクラスで描画しない
        private string title = "Team02";
        private GameRun gameRun;
        private InfinityGame.Element.Size tempScreen;
        private Load_Scene Load_Scene;
        private D_Void _Update;


        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            IGConfig.IGConfigLoad();
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            if (IGConfig.isFullScreen)
            {
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.PrimaryScreen;
                int tempsWidth = screen.Bounds.Width;
                int tempsHeight = screen.Bounds.Height;
                tempScreen = new InfinityGame.Element.Size(tempsWidth, tempsHeight);

                if (IGConfig.screen.Width > tempsWidth)
                {
                    IGConfig.screen.Width = tempsWidth;
                }
                if (IGConfig.screen.Height > tempsHeight)
                {
                    IGConfig.screen.Height = tempsHeight;
                }
                ChangeScreen.ChangeResolution(IGConfig.screen.Width, IGConfig.screen.Height);
            }
            graphicsDeviceManager.PreferredBackBufferWidth = IGConfig.screen.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = IGConfig.screen.Height;
            graphicsDeviceManager.IsFullScreen = IGConfig.isFullScreen;
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";
            IGConfig.MNCT = Content;
            IsMouseVisible = true;

            if (IGConfig.isFullScreen)
            {
                graphicsDeviceManager.ToggleFullScreen();
                _Update += SetFullScreen0;
                //Monogameのフルスクリーンからデスクトップに切り替えたときにゲームが真っ白になる問題を解決するため
            }
        }

        protected void SystemInitialize()
        {
            // この下にロジックを記述
            FirstInitialize();
            AfterInitialize();
            LastInitialize();
            // この上にロジックを記述

        }
        public void FirstInitialize()
        {
            Resources.SetGD(GraphicsDevice);
            GameTexts.Initialize(IGConfig.gameLanguage);
            gameRun = new GameRun(GraphicsDevice, graphicsDeviceManager, true);
            Load_Scene = new Load_Scene("Loading", GraphicsDevice, null, gameRun);
            gameRun.SetLoadScene(Load_Scene);
            Window.Title = GameTexts.GetText(title);
        }

        public void AfterInitialize()
        {
            gameRun.scenes["title"] = new TitleScene("title", GraphicsDevice, null, gameRun);
            gameRun.scenes["play"] = new PlayScene("play", GraphicsDevice, null, gameRun);
            gameRun.firstScene = "title";
        }

        public void LastInitialize()
        {
            gameRun.Initialize();
            gameRun.PreLoad();
        }

        public void FullScreen()
        {
            graphicsDeviceManager.ToggleFullScreen();
        }

        #region 「LoadContent」「UnloadContent」はgameRunの中で自動で処理するため、必要じゃなくなった。
        //gameRunの中で自動で処理するため、必要じゃなくなった。
        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
            //spriteBatch = new SpriteBatch(GraphicsDevice);  //このクラスで描画しない

            // この下にロジックを記述
            SystemInitialize();
            // この上にロジックを記述
            base.LoadContent();
        }

        /*/// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }*/
        #endregion
        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            //if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
            //     (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            //{
            //}
            if ((GameKeyboard.GetKeyState(Keys.RightAlt) || GameKeyboard.GetKeyState(Keys.LeftAlt)) && GameKeyboard.GetKeyTrigger(Keys.Enter))
                FullScreen();

            // この下に更新ロジックを記述
            gameRun.Update(gameTime);
            _Update?.Invoke();
            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.Black);

            // この下に描画ロジックを記述
            gameRun.Draw(gameTime);

            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        private void SetFullScreen0()
        {
            graphicsDeviceManager.ToggleFullScreen();
            _Update -= SetFullScreen0;
            _Update += SetFullScreen1;
        }

        private void SetFullScreen1()
        {
            graphicsDeviceManager.ToggleFullScreen();
            _Update -= SetFullScreen1;
        }

        /// <summary>
        /// ゲームが終了中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnExiting(object sender, EventArgs args)
        {
            if (IGConfig.isFullScreen)
            {
                ChangeScreen.ChangeResolution(tempScreen.Width, tempScreen.Height);
                //graphicsDeviceManager.ToggleFullScreen();
            }
            gameRun.IsGameRun = false;
            // while(gameRun.ov)
            base.OnExiting(sender, args);
        }

        /// <summary>
        /// ゲームが活動している状態
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnActivated(object sender, EventArgs args)
        {
            if (gameRun != null && gameRun.GameMouse != null)
                gameRun.GameMouse.Enable = true;
            base.OnActivated(sender, args);
        }

        /// <summary>
        /// ゲームが活動していない状態
        /// 他のアプリなどを操作している状態。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnDeactivated(object sender, EventArgs args)
        {
            if (gameRun != null && gameRun.GameMouse != null)
                gameRun.GameMouse.Enable = false;
            base.OnDeactivated(sender, args);
        }
    }
}
