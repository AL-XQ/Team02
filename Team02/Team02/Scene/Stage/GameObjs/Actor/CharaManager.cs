using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team02.Scene.Stage.GameObjs.Actor
{
    public class CharaManager
    {
        private Hero hero;
        private List<Enemy> enemys = new List<Enemy>();

        public Hero Hero { get => hero; set => hero = value; }

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
        }


    }
}
