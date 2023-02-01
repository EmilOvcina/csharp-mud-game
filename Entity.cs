using System;

namespace MUDProjekt
{
	public enum EntityType
	{
		BANDIT, 
		DWARF,
		MINOTAUR, 
		ORC, 
		ELF, 
		GOBLIN
	}

	public class Entity
	{
		public static Entity[] entityList = new Entity[18];

		//bandit
		public static Entity banditWarrior;
		public static Entity banditArcher;
		public static Entity banditMage;

		//dward
		public static Entity dwardWarrior;
		public static Entity dwarfArcher;
		public static Entity dwarfMage;

		//Minotaur
		public static Entity minotaurWarrior;
		public static Entity minotaurArcher;
		public static Entity minotaurMage;

		//orc
		public static Entity orcWarrior;
		public static Entity orcArcher;
		public static Entity orcMage;

		//elf
		public static Entity elfWarrior;
		public static Entity elfArcher;
		public static Entity elfMage;

		//goblin
		public static Entity goblinWarrior;
		public static Entity goblinArcher;
		public static Entity goblinMage;

		public int id;
		public string name;
		public int clas;
		public EntityType et;
		public int attack;
		public int health;
		public int speed;
		public int defence;

		//					  1 = Wizard, 2 = Archer, 3 = Warrior
		public Entity(int id, string name, int clas, EntityType et, int attack, int health, int speed, int defence)
		{
			this.id = id;
			this.name = name;
			this.clas = clas;
			this.et = et;
			this.attack = attack;
			this.health = health;
			this.speed = speed;
			this.defence = defence;
			entityList[id] = this;
		}

		public static void loadEntites()
		{
			Console.WriteLine("Loading, please wait.");
			goblinMage = generateEntity(17, "Goblin", 1, EntityType.GOBLIN);
			System.Threading.Thread.Sleep(100);
			goblinArcher = generateEntity(16, "Goblin", 2, EntityType.GOBLIN);
			System.Threading.Thread.Sleep(100);
			goblinWarrior = generateEntity(15, "Goblin", 3, EntityType.GOBLIN);
			System.Threading.Thread.Sleep(100);
			elfMage = generateEntity(14, "Elf", 1, EntityType.ELF);
			System.Threading.Thread.Sleep(100);
			elfArcher = generateEntity(13, "Elf", 2, EntityType.ELF);
			System.Threading.Thread.Sleep(100);
			elfWarrior = generateEntity(12, "Elf", 3, EntityType.ELF);
			System.Threading.Thread.Sleep(100);
			orcMage = generateEntity(11, "Orc", 1, EntityType.ORC);
			System.Threading.Thread.Sleep(100);
			orcArcher = generateEntity(10, "Orc", 2, EntityType.ORC);
			System.Threading.Thread.Sleep(100);
			orcWarrior = generateEntity(9, "Orc", 3, EntityType.ORC);
			System.Threading.Thread.Sleep(100);
			minotaurMage = generateEntity(8, "Minotaur", 1, EntityType.MINOTAUR);
			System.Threading.Thread.Sleep(100);
			minotaurArcher = generateEntity(7, "Minotaur", 2, EntityType.MINOTAUR);
			System.Threading.Thread.Sleep(100);
			minotaurWarrior = generateEntity(6, "Minotaur", 3, EntityType.MINOTAUR);
			System.Threading.Thread.Sleep(100);
			dwarfMage = generateEntity(5, "Dwarf", 1, EntityType.DWARF);
			System.Threading.Thread.Sleep(100);
			dwarfArcher = generateEntity(4, "Dwarf", 2, EntityType.DWARF);
			System.Threading.Thread.Sleep(100);
			dwardWarrior = generateEntity(3, "Dwarf", 3, EntityType.DWARF);
			System.Threading.Thread.Sleep(100);
			banditMage = generateEntity(2, "Bandit", 1, EntityType.BANDIT);
			System.Threading.Thread.Sleep(100);
			banditArcher = generateEntity(1, "Bandit", 2, EntityType.BANDIT);
			System.Threading.Thread.Sleep(100);
			banditWarrior = generateEntity(0, "Bandit", 3, EntityType.BANDIT);
			Console.WriteLine("Done loading.\n\n");
		}

		public static Entity generateEntity(int id, string name, int clas, EntityType et)
		{
			var r = new Random();
			int level = r.Next(1, 6);
			//Overhovedet ikke balanced, whatever. 
			//Man kan altid få EntityType til at gøre en betydning for hvordan tallene bliver genereret. 2
			int a = level * (6 + r.Next(-5, 5));
			int h = (level * 100) + r.Next(-50, 50);
			int s = level + r.Next(-6, 6);
			int d = level * r.Next(-4, 4);
			return new Entity(id, name, clas, et, a, h, s, d); 
		}
	}
}
