using System;
using TextAdventure.src;

namespace ZuulCS
{
    class Player
    {
        private Room _currentRoom;
        public uint health = 100;

        //public Game game;

        private Inventory inventory;

        internal Inventory Inventory { get => inventory; }

        private Enemies enemies;
        internal Enemies Enemies { get => enemies; }

        public Player()
        {
            inventory = new Inventory(8);
        }

        public void createRooms()
        {
            Room Big_Tree, Old_Shack, Cave, Path, shacksecondfloor, Village, Church, Blacksmith, House1, House2, ChurchAttic;

            // create the rooms
            Big_Tree = new Room("next to a big tree");
            Old_Shack = new Room("in an old empty Shack");
            Cave = new Room("in a cave");
            Path = new Room("at the path to get out of the forest");
            shacksecondfloor = new Room("on the second floor of the shack");
            Village = new Room("in a small village");
            Church = new Room("in the church");
            House1 = new Room("at a house");
            House2 = new Room("in an empty house");
            Blacksmith = new Room("at the blacksmith");
            ChurchAttic = new Room("in the church attic");

            // initialise room exits
            Big_Tree.setExit("east", Old_Shack);
            Big_Tree.setExit("south", Cave);
            Big_Tree.setExit("west", Path);

            Old_Shack.setExit("west", Big_Tree);
            Old_Shack.setExit("up", shacksecondfloor);

            Path.setExit("east", Big_Tree);
            Path.setExit("west", Village);

            Village.setExit("east", Path);
            Village.setExit("north", Church);
            Village.setExit("south", Blacksmith);
            Village.setExit("west", House1);

            Church.setExit("up", ChurchAttic);
            Church.setExit("south", Village);

            ChurchAttic.setExit("down", Church);

            Blacksmith.setExit("north", Village);

            House1.setExit("west", House2);
            House1.setExit("east", Village);

            House2.setExit("east", House1);

            Cave.setExit("north", Big_Tree);

            shacksecondfloor.setExit("down", Old_Shack);

            _currentRoom = Big_Tree;  // start game outside

            for (int i = 0; i < 1; i++)
            {
                Potion potion = new Potion();
                Big_Tree.Inventory.addItem(potion);
 
                Stake stake = new Stake();
                Old_Shack.Inventory.addItem(stake);

                BloodVial vial = new BloodVial();
                shacksecondfloor.Inventory.addItem(vial);

                Human human = new Human();
                Old_Shack.Enemies.addEnemy(human);

            }
        }

        public Room currentRoom
        {
            get { return this._currentRoom; }
            set { this._currentRoom = value; }
        }

        public void isAlive()
        {
            if (health > 0)
            {
                Console.WriteLine("Health: " + health);
            }else if(health <= 0)
            {
                Console.WriteLine("You Died");
                Environment.Exit(0);
            }
        }

        public void Damage(uint amount)
        {
            if (health > 0)
            {
                health -= amount;
                isAlive();
            }
            
        }

        public void Heal(uint amount)
        {
            if (health < 100)
            {
                health += amount;
            }
            else
            {
                Console.WriteLine("U are already on max health!");
            }
        }
    }
}
