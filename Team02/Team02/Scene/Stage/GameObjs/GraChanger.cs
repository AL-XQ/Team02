using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Actor;

namespace Team02.Scene.Stage.GameObjs
{
    public class GraChanger
    {
        private Base_Stage stage;
        private Vector2 center;
        private bool isOver = false;
        private List<Chara> charas = new List<Chara>();
        private Vector2 gra;
        private int overTime;
        private bool enable = false;

        public bool IsOver { get => isOver; }
        public List<Chara> Charas { get => charas; }
        public Vector2 Gra { get => gra; set => gra = value; }
        public bool Enable { get => enable; }
        public Vector2 Center { get => center; set => center = value; }

        public GraChanger(Base_Stage stage)
        {
            this.stage = stage;
            stage.NowChanger = this;
        }

        public void EnableGra()
        {
            if (enable)
                return;
            enable = true;
            overTime = 180;
            foreach (var l in charas)
            {
                l.Gra = gra;
            }
            stage.NowChanger = null;
            stage.GraChangers.Add(this);
        }
        public void EnableGra(Vector2 gra)
        {
            this.gra = gra;
            EnableGra();
        }

        public void Update(GameTime gameTime)
        {
            if (enable)
            {
                CountDown();
            }
        }

        private void CountDown()
        {
            if (overTime > 0)
            {
                overTime--;
                return;
            }
            foreach(var l in charas)
            {
                l.ResetGra();
            }
            Kill();
        }

        public void Kill()
        {
            isOver = true;
            stage = null;
            charas.Clear();
        }
    }
}
