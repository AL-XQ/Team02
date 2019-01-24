using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.Device;
using InfinityGame.Element;
using InfinityGame.GameGraphics;
using InfinityGame.UI;
using InfinityGame.UI.UIContent;

using Microsoft.Xna.Framework;

namespace Team02.Scene.UI
{
    public class Credit : UIWindow
    {
        private AnimeButton ok;
        private Label lable;
        public Credit(BaseDisplay parent) : base(parent)
        {
            BorderOn = false;
            CanClose = false;
            CanMove = false;
            backColor = Color.Transparent;
            visible = false;
        }

        public override void PreLoadContent()
        {
            size = parent.Size / 2;
            Location = ((parent.Size - size) / 2).ToPoint();
            ok = new AnimeButton(this);
            ok.Size = new Size(360, 60);
            ok.Location = new Point((size.Width - ok.Size.Width) / 2, size.Height - ok.Size.Height - 20);
            ok.Text = GetText("ok");
            ok.BDText.ForeColor = System.Drawing.Color.White;
            lable = new Label(this);
            lable.BDText.ForeColor = System.Drawing.Color.White;
            lable.Text = "　　　　　　　クレジット\r\n" +
                         "　チーム　　　　　　　　：Team02\r\n" +
                         "　プランナー（リーダー）：楊　海松\r\n" +
                         "　メインプログラマー　　：謝　少杰\r\n" +
                         "　プログラマー　　　　　：謝　少杰\r\n" +
                         "　　　　　　　　　　　　　鶴見　昌之\r\n" +
                         "　　　　　　　　　　　　　中村　翔\r\n" +
                         "　　　　　　　　　　　　　總領　辰哉\r\n" +
                         "　デザイナー　　　　　　：楊　海松\r\n" +
                         "　デザイン　　　　　　　：全員\r\n" +
                         "　サウンド　　　　　　　：フリー素材";
            lable.Location = new Point((size.Width - lable.Size.Width) / 2, 20);
            base.PreLoadContent();
        }

        public override void LoadContent()
        {
            ok.Image = ImageManage.GetSImage("button");
            ok.Click += OK_Click;
            ok.ImageEntity.Enable = false;
            image = ImageManage.GetSImage("window_ui.png");
            base.LoadContent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
