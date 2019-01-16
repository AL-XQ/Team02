using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InfinityGame.Element;

using Team02.Scene.UI;

using Microsoft.Xna.Framework;
using Team02.Scene.Stage.GameObjs.Actor.AI;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class CharaManager
    {
        private Hero hero;
        private Base_Stage stage;
        private List<Enemy> enemys = new List<Enemy>();
        private Dictionary<Chara, CharaHpUI> hpUIs = new Dictionary<Chara, CharaHpUI>();

        public Hero Hero { get => hero; set => SetHero(value); }
        public List<Enemy> Enemys { get => enemys; }

        public CharaManager(Base_Stage base_Stage)
        {
            stage = base_Stage;
        }

        public void Initialize()
        {
            hero = null;
            enemys.Clear();
        }

        private void SetHero(Hero value)
        {
            hero = value;
            if (hero != null)
            {
                var ui = new CharaHpUI(hero.Stage);
                ui.Target = hero;
                ui.Create();
                hpUIs.Add(hero, ui);
            }
        }

        public Enemy GetEnemy(int id)
        {
            return enemys[id];
        }
        public void Add(Enemy enemy)
        {
            enemys.Add(enemy);
            var ui = new CharaHpUI(enemy.Stage);
            ui.Target = enemy;
            ui.Create();
            hpUIs.Add(enemy, ui);
        }

        public Enemy CreateEnemy(Vector2 coo, Size size, BehaviourManager ai, string name = "Null")
        {
            var enemy = new Enemy(stage, name);
            enemy.Coordinate = coo;
            enemy.Size = size;
            enemy.BehaviourManager = ai;
            enemy.Create();
            return enemy;
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
            {
                Hero = null;
                var ui = hpUIs[chara];
                hpUIs.Remove(chara);
                ui.Kill();
            }
        }
    }
}
