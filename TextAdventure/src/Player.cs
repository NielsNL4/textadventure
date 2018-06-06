using System;

namespace ZuulCS
{
    class Player
    {
        private Room _currentRoom;
        public uint health = 100;

        public Game game;
        //private Inventory inventory;

       // internal Inventory Inventory { get => inventory; }

        public Player(){
            //inventory = new Inventory(8);
        }


        public void createRooms()
        {
            Room outside, theatre, pub, lab, office, cloud, uranus, ded;

            // create the rooms
            outside = new Room("outside the main entrance of the university");
            theatre = new Room("in a lecture theatre");
            pub = new Room("in the campus pub");
            lab = new Room("in The Lab");
            cloud = new Room("on a cloud");
            office = new Room("in the office");
            uranus = new Room("in uranus");
            ded = new Room("splashed to ur death");

            // initialise room exits
            outside.setExit("east", theatre);
            outside.setExit("south", lab);
            outside.setExit("west", pub);
            outside.setExit("up", cloud);

            theatre.setExit("west", outside);

            pub.setExit("east", outside);

            lab.setExit("south", office);
            lab.setExit("north", outside);

            office.setExit("west", lab);

            cloud.setExit("down", outside);
            cloud.setExit("up", uranus);

            uranus.setExit("down", cloud);

            _currentRoom = outside;  // start game outside
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
            health -= amount;
        }

        public void heal(uint amount)
        {
            health += amount;
        }

    }
}
