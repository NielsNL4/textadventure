using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace TextAdventure.src
{
    class Inventory
    {
        private List<Item> items;
        private int maxWeight;
        private int weightLeft;

        internal List<Item> Items { get => items;  }
        internal int WeightLeft { get => maxWeight - items.Count; }

        private BloodVial bloodvial;

        private Player player;

        public Inventory(int amount)
        {
            items = new List<Item>();
            maxWeight = amount;
        }

        public bool addItem(Item item)
        {
            uint currentWeight = 0;

            for(int i = items.Count - 1; i >=0; i--)
            {
                currentWeight++;
            }

            if(currentWeight < maxWeight)
            {
                items.Add(item);
                return (true);
            }

            Console.WriteLine("Your inventory is too heavy...");
            return (false);
        }

        public bool takeItem(Inventory other, string key)
        {
            for(int i = items.Count-1; i>= 0; i--)
            {
                if(items[i].Name == key)
                {
                    if (other.addItem(items[i]))
                    {
                        items.Remove(items[i]);
                        return true;
                    }
                }
            }

            Console.WriteLine("U don't have that item...");
            return (false);
        }

        public bool useItem(string key, Player player)
        {

            this.player = player;

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (items[i].Name == key)
                {
                    if (key == "bloodvial")
                    {
                        player.Damage(25);
                        items.Remove(items[i]);
                        return (true);
                    }
                    if (key == "potion" && player.health < 100)
                    {
                        player.Heal(10);
                        player.isAlive();
                        items.Remove(items[i]);
                        return (true);
                    }
                }
            }
            return (false);
        }
    }
}
