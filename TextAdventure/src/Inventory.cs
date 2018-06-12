using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure.src
{
    class Inventory
    {
        private List<Item> items;
        private int maxWeight;
        private int weightLeft;

        internal List<Item> Items { get => items;  }
        internal int WeightLeft { get => maxWeight - items.Count; }

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

        public bool sendItem(Inventory other, string key)
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
    }
}
