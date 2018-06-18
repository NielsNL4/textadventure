using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.src
{
    class Enemies
    {
        private List<Enemy> enemies;

        internal List<Enemy> _Enemies { get => enemies; }

        private Human human;

        public Enemies(int amount)
        {
            enemies = new List<Enemy>();
        }

        public bool addEnemy(Enemy enemy)
        {
            uint currentEnemies = 0;

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                currentEnemies++;
            }

            enemies.Add(enemy);
            return (true);
        }

        public bool attackEnemy(string key, Enemies other)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].Name == key)
                {
                    if(key == "Human")
                    {
                        human.Damage(20);
                    }
                }
            }
            return (false);
        }
    }
}
