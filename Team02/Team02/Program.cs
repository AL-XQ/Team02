﻿using System;

namespace Team02
{
#if WINDOWS || LINUX
    /// <summary>
    /// メインクラス
    /// （ゲームプログラムの実体生成と実行を行っている）
    /// </summary>
    public static class Program
    {
        private static Game1 game = new Game1();
        /// <summary>
        /// プロジェクトで一番最初に動くメソッド Main
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ゲームオブジェクトの実体生成
            //using (var game = new InfinitySpace())
            game.Run(); //ゲームの実行
        }

        public static void Exit()
        {
            game.Exit();
        }

        public static void FullScreen()
        {
            game.FullScreen();
        }
    }
#endif
}
