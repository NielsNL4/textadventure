using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace TextAdventure.src
{
    class Enemy
    {
        protected string name;
        protected string description;

        internal string Name { get => name; }
        internal string Description { get => description; }

        private uint health = 100;

        internal uint Health { get => health; set => health = value; }

        private Player player;

        public void Attack(Player player)
        {
            this.player = player;

            int amount;

            Random randomInt = new Random();

            amount = randomInt.Next(5, 15);

            player.Damage(Convert.ToUInt32(amount));
        }

        public void Damage(uint amount)
        {
            health -= amount;
            isAlive();
        }

        public void isAlive()
        {
            if (health > 0)
            {
                Console.WriteLine("Enemy haelyh is now: " + health);
            }
            else if (health <= 0)
            {
                Console.WriteLine("You killed the enemy");
            }
        }

    }
}
