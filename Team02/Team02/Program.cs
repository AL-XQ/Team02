using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Team02
{
#if WINDOWS || LINUX
    /// <summary>
    /// メインクラス
    /// （ゲームプログラムの実体生成と実行を行っている）
    /// </summary>
    public static class Program
    {
        private static Game1 game;
#if DEBUG
        public static bool MapEdit = false;
#endif
        public static Game1 Game { get => game; }

        /// <summary>
        /// プロジェクトで一番最初に動くメソッド Main
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // ゲームオブジェクトの実体生成
            //using (var game = new InfinitySpace())
            game = new Game1();
#if DEBUG
            //
            if (MapEdit)
            {
                game.Window.AllowAltF4 = false;
                IntPtr hMenu = GetSystemMenu(game.Window.Handle, 0);
                RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
            }
#endif
            game.Run(); //ゲームの実行
        }

#if DEBUG
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);
        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

#endif

        public static void Exit()
        {
#if DEBUG
            if (!MapEdit)
#endif
                game.Exit();
        }

        public static void FullScreen()
        {
            game.FullScreen();
        }
    }
#endif
}
