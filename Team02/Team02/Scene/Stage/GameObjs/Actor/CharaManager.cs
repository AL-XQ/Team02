using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Team02.Scene.UI;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class CharaManager
    {
        private Hero hero;
        private List<Enemy> enemys = new List<Enemy>();
        private Dictionary<Enemy, EnemyHpUI> hpUIs = new Dictionary<Enemy, EnemyHpUI>();

        public Hero Hero { get => hero; set => hero = value; }
        public List<Enemy> Enemys { get => enemys; }

        public CharaManager()
        {

        }

        public void Initialize()
        {
            hero = null;
            enemys.Clear();
        }

        public Enemy GetEnemy(int id)
        {
            return enemys[id];
        }
        public void Add(Enemy enemy)
        {
            enemys.Add(enemy);
            var ui = new EnemyHpUI(enemy.Stage);
            ui.Target = enemy;
            ui.Create();
            hpUIs.Add(enemy, ui);
        }

        public void Remove(Chara chara)
        {
            if (chara is Enemy e)
            {
                enemys.Remove(e);
                var ui = hpUIs[e];
                hpUIs.Remove(e);
                ui.Kill();
                return;
            }
            if (chara == hero)
                Hero = null;
        }
    }
}
