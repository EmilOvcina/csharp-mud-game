using System;
using System.Collections.Generic;

namespace MUDProjekt
{
	public enum RoomType
	{
		START, LOOT, FORREST, CITY, STORE, FIELD, ROAD, SAVANNA, BOSS
	}

	public class Room
	{
		public int id;
		public bool isCleared;
		public bool isBoss;
		public RoomType rt;

		public List<Item> lootListe = new List<Item>();
		public List<Entity> monsterListe = new List<Entity>();

		public Room(int id, RoomType rt)
		{
			this.id = id;
			isCleared = false;
			this.rt = rt;
		}

		public Room(int id, bool isCleared, RoomType rt)
		{
			this.id = id;
			this.isCleared = isCleared;
			this.rt = rt;
		}

		public void generateMonster()
		{
			var r = new Random();
			if(rt != RoomType.START & rt != RoomType.CITY & rt != RoomType.STORE & r.Next(0, 10) >= 7)
			{
				for (int i = 0; i < r.Next(1, 3); i++)
				{
					monsterListe.Add(Entity.entityList[r.Next(0, Entity.entityList.Length - 1)]);
				}
			}
		}

		public void generateLoot()
		{
			var r = new Random();
			if(rt == RoomType.LOOT || r.Next(0, 10) > 5)
			{
				for (int i = 0; i < r.Next(1, 5); i++)
				{
					lootListe.Add(Item.itemsList[r.Next(0, Item.itemsList.Length - 1)]);
				}
			}
		}

		public void loot()
		{
			foreach(Item item in lootListe)
			{
				if (Player.inv.ToArray().Length >= 32)
				{
					Console.WriteLine("Your Invntory is full");
				}
				else {
					Console.WriteLine("You have found one " + item.name + "!");
					Player.addItemToInv(item);
				}
			}

			lootListe.Clear();
		}

		public bool getIsCleared()
		{
			return isCleared;
		}

		public void setIsCleared(bool iscleared)
		{
			isCleared = iscleared;
		}
	}
}