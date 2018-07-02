using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace TextAdventure.src
{
    class Item
    {
        protected string name;
        protected string description;

        internal string Name { get => name; }
        internal string Description { get => description; }

        public Item()
        { 
            name = "Item";

            description = "A strange looking object";          
        }
    }
}
