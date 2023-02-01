using System;
namespace MUDProjekt
{
	public class Game
	{
		public int pClass;
		public Dungeon dungeon1;

		public static char[] map;

		public Game()
		{
			map = new char[MainClass.WIDTH * MainClass.HEIGHT];
			for (int i = 0; i < map.Length; i++)
				map[i] = ' ';
		}

		public void playIntro()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("You have been asked by your king to help him.");
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("He asked you to clear out the creatures in the wild, \nwho is harming his people");
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("Your rewards for your quest are to live in the kings palace, and be knighted");
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("You immidiately set out on your journey...");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public void chooseClass()
		{
			Console.WriteLine("\nChoose your class adventurere.");
			Console.WriteLine("Available classes: ");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write("Mage ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(" Archer ");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(" Warrior\n");
			Console.ForegroundColor = ConsoleColor.White;
			string input = Console.ReadLine();

			switch (input.ToLower()) 
			{
				case "mage":
					setpClass(1);
					Console.WriteLine("Welcome Mage.");
					playGame();
					break;

				case "archer":
					setpClass(2);
					Console.WriteLine("Welcome Archer.");
					playGame();
					break;

				case "warrior":
					setpClass(3);
					Console.WriteLine("Welcome Warrior.");
					playGame();
					break;

				default:
					Console.WriteLine("That Class dosn't exist");
					chooseClass();
					break;
			}
		}

		public void playGame()
		{
			dungeon1 = new Dungeon(0);
			dungeon1.generateRoom();
			Entity.loadEntites();
			dungeon1.renderMap();
			renderMap();
			Console.Write('\n');
			Console.WriteLine("\nType help, for a list of available commands");
			switch (Player.pClass)
			{
				case 3:
					Player.addItemToInv(Item.swordIron);
					Player.health = 300;
					Player.attack = 50;
					Player.speed = 5;
					Player.defence = 20;
					break;
				case 2:
					Player.addItemToInv(Item.bowShort);
					Player.attack = 35;
					Player.health = 270;
					Player.speed = 15;
					Player.defence = 7;
					break;
				case 1:
					Player.addItemToInv(Item.staffRegular);
					Player.attack = 42;
					Player.health = 240;
					Player.speed = 10;
					Player.defence = 3;
					break;
			}
			gameLoop();
		}

		public void gameLoop()
		{
			if (Player.health <= 0)
				die();
			var input = Console.ReadLine();
			string rt = dungeon1.rumListe[Player.getRoomId()].rt.ToString();
			switch (input.ToLower())
			{
				case "help":
					displayHelp();
					break;
				case "wr":
					if (Player.RoomID == 31 || Player.RoomID == 23 || Player.RoomID == 15 || Player.RoomID == 7)
						Console.WriteLine("You can't walk right any further");
					else {
						if (dungeon1.rumListe[Player.RoomID + 1].getIsCleared() == false)
						{
							dungeon1.rumListe[Player.RoomID + 1].generateLoot();
							dungeon1.rumListe[Player.RoomID + 1].generateMonster();
						}
						Player.setRoomId(Player.RoomID + 1);
						dungeon1.rumListe[Player.RoomID].setIsCleared(true);
						Console.WriteLine("You entered a " + rt.ToLower() + " area");
						if (dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length >= 1)
							if (dungeon1.rumListe[Player.RoomID].monsterListe[0] != null)
								enterBattle();
					}

					gameLoop();
					break;

				case "wl":
					if (Player.RoomID == 0 || Player.RoomID == 8 || Player.RoomID == 24 || Player.RoomID == 16)
						Console.WriteLine("You can't walk left any further");
					else {
						if (dungeon1.rumListe[Player.RoomID - 1].getIsCleared() == false)
						{
							dungeon1.rumListe[Player.RoomID - 1].generateLoot();
							dungeon1.rumListe[Player.RoomID - 1].generateMonster();
						}
						Player.setRoomId(Player.RoomID - 1);
						dungeon1.rumListe[Player.RoomID].setIsCleared(true);
						Console.WriteLine("You entered a " + rt.ToLower() + " area");
						if (dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length >= 1)
							if (dungeon1.rumListe[Player.RoomID].monsterListe[0] != null)
								enterBattle();
					}

					gameLoop();
					break;

				case "wu":
					if (Player.RoomID <= 7)
						Console.WriteLine("You can't walk up any longer");
					else {
						if (dungeon1.rumListe[Player.RoomID - 8].getIsCleared() != true)
						{
							dungeon1.rumListe[Player.RoomID - 8].generateLoot();
							dungeon1.rumListe[Player.RoomID - 8].generateMonster();
						}
						Player.setRoomId(Player.RoomID - 8);
						dungeon1.rumListe[Player.RoomID].setIsCleared(true);
						Console.WriteLine("You entered a " + rt.ToLower() + " area");
						if (dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length >= 1)
							if(dungeon1.rumListe[Player.RoomID].monsterListe[0] != null)
								enterBattle();
					}
					gameLoop();
					break;
					
				case "wd":
					if (Player.RoomID >= 24)
						Console.WriteLine("You can't walk down any longer");
					else {
						if (dungeon1.rumListe[Player.RoomID + 8].getIsCleared() == false)
						{
							dungeon1.rumListe[Player.RoomID + 8].generateLoot();
							dungeon1.rumListe[Player.RoomID + 8].generateMonster();
						}
						Player.setRoomId(Player.RoomID + 8);
						dungeon1.rumListe[Player.RoomID].setIsCleared(true);
						Console.WriteLine("You entered a " + rt.ToLower() + " area");
						if(dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length >= 1)
							if (dungeon1.rumListe[Player.RoomID].monsterListe[0] != null)
								enterBattle();
						
					}

					gameLoop();
					break;

				case "map":
					dungeon1.renderMap();
					renderMap();
					Console.Write('\n');
					gameLoop();
					break;

				case "gm":
					Console.Write('\n');
					gameLoop();
					break;

				case "loot":
					if (dungeon1.rumListe[Player.RoomID].lootListe.ToArray().Length >= 1)
					{
						Console.WriteLine("looting");
						dungeon1.rumListe[Player.RoomID].loot();
					}
					else
						Console.WriteLine("There is currently no loot in this room.");
					gameLoop();
					break;

				case "inv":
					Player.displayInv();
					gameLoop();
					break;

				default:
					Console.WriteLine("That command doesn't exist. Type 'help' for a list of available commands");
					gameLoop();
					break;
			}
		}

		public void displayHelp()
		{
			//Vis liste af alle kommandoer
			Console.WriteLine("wl   - Walk Left");
			Console.WriteLine("wr   - Walk Right");
			Console.WriteLine("wu   - Walk Up");
			Console.WriteLine("wd   - Walk Down");
			Console.WriteLine("map  - Show Map");
			Console.WriteLine("inv  - Show Inventory");
			Console.WriteLine("loot - Check your current room for loot, and loot it.");
			gameLoop();
		}

		public void enterBattle()
		{
			Console.WriteLine("\n\nYou have entered a battle with: ");
			foreach (Entity entity in dungeon1.rumListe[Player.RoomID].monsterListe)
				Console.WriteLine(entity.name);
			Console.Write("\nType help, for a list of available commands in combat.\n");

			fight();
		}

		public void fight()
		{
			string input = Console.ReadLine();
			if (Player.health <= 0)
				die();
			if (dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length == 0)
			{
				Console.WriteLine("\nYou won the battle, type loot to check for loot");
				Player.health += 200;
				dungeon1.rumListe[Player.RoomID].generateLoot();
				gameLoop();
			}
			switch (input)
			{
				case "help":
					displayBattleHelp();
					fight();
					break;

				case "stats":
					Console.WriteLine("Health: " + Player.health);
					Console.WriteLine("Attack: " + Player.attack);
					Console.WriteLine("Speed: " + Player.speed);
					Console.WriteLine("Defence: " + Player.defence);
					fight();
					break;

				case "inv":
					Player.displayInv();
					fight();
					break;

				case "foes":
					foreach(Entity ent in dungeon1.rumListe[Player.RoomID].monsterListe) {
						string classS = "";

						switch (ent.clas)
						{
							case 1:
								classS = "Warrior";
								break;
							case 2:
								classS = "Archer";
								break;
							case 3:
								classS = "Mage";
								break;
						}

						Console.WriteLine(ent.name + ": " + classS);
						Console.WriteLine("Health: " + ent.health);
						Console.WriteLine("Attack: " + ent.attack);
						Console.WriteLine("Speed: " + ent.speed);
						Console.WriteLine("Defence: " + ent.defence);
						Console.Write("\n");
					}
					fight();
					break;

				case "a":
					attack();
					Console.Write("\n");
					break;

				case "fight":
					untilDeath();
					fight();
					break;

				case "flee":
					Console.WriteLine("You ran from battle, but got hit while escaping");
					Player.attack -= 4;
					Player.speed -= 3;
					Player.defence -= 4;
					Player.health -= 30;
					gameLoop();
					break;

				default:
					Console.WriteLine("That command doesn't exist. Type 'help' for a list of available commands");
					fight();
					break;
			}

			gameLoop();
		}

		public void displayBattleHelp()
		{
			Console.WriteLine("stats  - Show current stats");
			Console.WriteLine("inv    - Show inventory");
			Console.WriteLine("foes   - Show stats of whom your fighting");
			Console.WriteLine("a      - Attack the enemy once");
			Console.WriteLine("fight  - Attack the enemy until the battle is over");
			Console.WriteLine("Flee   - Run from battle, but you will loose stats and health.");
		}

		public void attack()
		{
			var r = new Random();
			var ent = dungeon1.rumListe[Player.RoomID].monsterListe[0];
			if (ent.health <= 0)
			{
				dungeon1.rumListe[Player.RoomID].monsterListe.Remove(ent);
				fight();
			}
			if (ent.speed > Player.speed)
			{
				Console.WriteLine("Your opponent goes for an attack");
				System.Threading.Thread.Sleep(100);
				if (r.Next(0, 20) >= Player.defence)
				{
					int dmgTaken = Math.Abs(ent.attack + r.Next(-10, 10));
					Player.health -= dmgTaken;
					Console.WriteLine("Your opponent strikes you, dealing " + dmgTaken + " damage");
				}
				else {
					Console.WriteLine("Your opponent missed you");
				}
				System.Threading.Thread.Sleep(1000);
				if (Player.health >= 1)
				{
					Console.WriteLine("You go for an attack");
					System.Threading.Thread.Sleep(100);
					if (r.Next(0, 20) >= ent.defence)
					{
						int dmgTaken = Math.Abs(Player.attack + r.Next(-10, 10));
						ent.health -= dmgTaken;
						Console.WriteLine("You strike your opponent, dealing " + dmgTaken + " damage");
					}
					else {
						Console.WriteLine("You missed your opponent");
					}
				}
				else
					die();

			} else {
				if (Player.health >= 1)
				{
					Console.WriteLine("You go for an attack");
					System.Threading.Thread.Sleep(100);
					if (r.Next(0, 20) >= ent.defence)
					{
						int dmgTaken = Math.Abs(Player.attack + r.Next(-10, 10));
						ent.health -= dmgTaken;
						Console.WriteLine("You strike your opponent, dealing " + dmgTaken + " damage");
					}
					else {
						Console.WriteLine("You missed your opponent");
					}
				}
				else
					die();
				System.Threading.Thread.Sleep(1000);
				Console.WriteLine("Your opponent goes for an attack");
				System.Threading.Thread.Sleep(100);
				if (r.Next(0, 20) >= Player.defence)
				{
					int dmgTaken = Math.Abs(ent.attack + r.Next(-10, 10));
					Player.health -= dmgTaken;
					Console.WriteLine("Your opponent strikes you, dealing " + dmgTaken + " damage");
				}
				else {
					Console.WriteLine("Your opponent missed you");
				}
			}
			if (ent.health <= 0)
			{
				dungeon1.rumListe[Player.RoomID].monsterListe.Remove(ent);
				fight();
			}
			fight();
		}

		public void die()
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("You have died");
			System.Threading.Thread.Sleep(1000);
			Environment.Exit(0);
		}

		public void untilDeath()
		{
			while(Player.health >= 1 && dungeon1.rumListe[Player.RoomID].monsterListe.ToArray().Length >= 1) 
			{
				var r = new Random();
				var ent = dungeon1.rumListe[Player.RoomID].monsterListe[0];
				if (ent.health <= 0)
				{
					dungeon1.rumListe[Player.RoomID].monsterListe.Remove(ent);
				}
				if (ent.speed > Player.speed)
				{
					if (r.Next(0, 20) >= Player.defence)
					{
						int dmgTaken = Math.Abs(ent.attack + r.Next(-10, 10));
						Player.health -= dmgTaken;
					}

					if (Player.health >= 1)
					{
						if (r.Next(0, 20) >= ent.defence)
						{
							int dmgTaken = Math.Abs(Player.attack + r.Next(-10, 10));
							ent.health -= dmgTaken;
						}
					}
					else
						die();

				}
				else {
					if (
						Player.health >= 1)
					{
						if (r.Next(0, 20) >= ent.defence)
						{
							int dmgTaken = Math.Abs(Player.attack + r.Next(-10, 10));
							ent.health -= dmgTaken;
						}
					}
					else
						die();
					
					if (r.Next(0, 20) >= Player.defence)
					{
						int dmgTaken = Math.Abs(ent.attack + r.Next(-10, 10));
						Player.health -= dmgTaken;

					}
				}
				if (ent.health <= 0)
				{
					dungeon1.rumListe[Player.RoomID].monsterListe.Remove(ent);
				}
			}
			System.Threading.Thread.Sleep(5000);
			Console.WriteLine("The battle is over. Press enter to discover the result...");
			fight();
		}

		public void renderMap()
		{
			for (int i = 0; i < MainClass.WIDTH * MainClass.HEIGHT; i++)
			{
				map[i] = Screen.map[i];
			}

			for (int i = 0; i < map.Length; i++)
			{
				if (i % 32 == 0)
					Console.Write("\n");
				else 
					Console.Write(map[i]);
			}
		}

		public void setpClass(int pc)
		{
			pClass = pc;
			Player.pClass = pc;
		}

		public int getpClass()
		{
			return Player.pClass;
		}
	}
}