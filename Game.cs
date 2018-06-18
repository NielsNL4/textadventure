using System;
using TextAdventure.src;

namespace ZuulCS
{
	public class Game
	{
		private Parser parser;
        private Player player;
        private Enemies enemies;
        public bool finished = false;
        public bool wantToQuit = false;

        internal Player _player { get => player; }

        public Game ()
		{
            player = new Player();
            parser = new Parser();

            player.createRooms();
		}

		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
            }
            Console.WriteLine("Thank you for playing.");

		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
            Console.WriteLine("U wake up with a terrible hunger.");
            Console.WriteLine("You are lost. You are alone.");
            Console.WriteLine("You wander around in a forest.");
            Console.WriteLine();
            Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
					printHelp();
					break;
				case "go":
					goRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
                case "look":
                    goLook();
                    break;
                case "health":
                    showHealth();
                    break;
                case "take":
                    getItem(command);
                    break;
                case "inventory":
                    showInventory();
                    break;
                case "drop":
                    dropItem(command);
                    break;
                case "use":
                    UseItem(command);
                    break;
                case "hit":
                    hitMe();
                    break;
                case "attack":
                    AttackEnemy(command);
                    break;

			}

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
            Console.WriteLine("U wake up with a terrible hunger.");
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around in a forest.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

        private void goLook()
        {
            Console.WriteLine(player.currentRoom.getLongDescription());
            Console.WriteLine(player.currentRoom.Inventory.Items.Count + " Item(s) found!");
            Console.WriteLine(player.currentRoom.Enemies._Enemies.Count + " Enem(y)(ies) here!");
            for (int i = 0; i < player.currentRoom.Inventory.Items.Count; i++)
            {
                Console.WriteLine((i + 1) + " | " + player.currentRoom.Inventory.Items[i].Name + ": " + player.currentRoom.Inventory.Items[i].Description);
            }
            for (int i = 0; i < player.currentRoom.Enemies._Enemies.Count; i++)
            {
                Console.WriteLine((i + 1) + " | " + player.currentRoom.Enemies._Enemies[i].Name + ": " + player.currentRoom.Enemies._Enemies[i].Description);
            }
        }

		/**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
		private void goRoom(Command command)
		{
			if(!command.hasSecondWord()) {
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
            }

			string direction = command.getSecondWord();

			// Try to leave current room.
			Room nextRoom = player.currentRoom.getExit(direction);

			if (nextRoom == null) {
				Console.WriteLine("There is no door to "+direction+"!");
			} else {
				player.currentRoom = nextRoom;
				Console.WriteLine(player.currentRoom.getLongDescription());
			}
		}

        private void showInventory()
        {
            for (int i = 0; i < player.Inventory.Items.Count; i++)
            {

                Console.WriteLine((i + 1) + " | " + player.Inventory.Items[i].Name + ": " + player.Inventory.Items[i].Description);

            }
        }

        private void showHealth()
        {
            Console.WriteLine(player.health);
        }

        private void getItem(Command command)
        {

            if (!command.hasSecondWord())
            {
                Console.WriteLine("Take what?");
            }
            else
            {

                if (player.Inventory.WeightLeft > 0)
                {
                    player.currentRoom.Inventory.takeItem(player.Inventory, command.getSecondWord());
                    Console.WriteLine("U picked up an item!");
                }
                else
                {

                    Console.WriteLine("Not enough space in inventory to take item!");

                }

            }

        }

        private void dropItem(Command command)
        {
            if (!command.hasSecondWord())
            {
                if (player.Inventory.Items.Count < player.currentRoom.Inventory.WeightLeft)
                {
                    for (int i = player.Inventory.Items.Count; i >= 0; i--)
                    {

                        player.Inventory.takeItem(player.currentRoom.Inventory, player.Inventory.Items[i].Name);

                    }
                }
            }
            else
            {
                if (player.currentRoom.Inventory.WeightLeft > 0)
                {
                    player.Inventory.takeItem(player.currentRoom.Inventory, command.getSecondWord());
                    Console.WriteLine("U dropeed an item");
                }
            }
        }

        private void UseItem(Command command)
        {
            if (!command.hasSecondWord())
            {
                Console.WriteLine("Use what?");
            }
            else
            {
                player.Inventory.useItem(command.getSecondWord(), player);
            }
        }

        private void hitMe()
        {
            player.Damage(10);
        }

        private void AttackEnemy(Command command)
        {
            if (!command.hasSecondWord())
            {
                Console.WriteLine("Attack what?");
            }
            else
            {
                player.currentRoom.Enemies.attackEnemy(command.getSecondWord(), enemies);
            }
        }
    }
}