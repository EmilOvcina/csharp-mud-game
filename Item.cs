using System;
namespace MUDProjekt
{
	public class Item
	{
		public static Item[] itemsList = new Item[16];

		//Currency
		public static Item coinGold = new Item(0, "Gold Coin");
		public static Item coinSilver = new Item(12, "Silver Coin");
		public static Item coinBronze = new Item(13, "Bronze Coin");

		//Potions
		public static Item potionH = new Item(1, "Health Potion");
		public static Item potionMaH = new Item(10, "Minor Health Potion");
		public static Item potionMiH = new Item(11, "Major Health Potion");

		//Weaponry
		public static Item swordSteel = new Item(2, "Steel Sword");
		public static Item swordIron = new Item(3, "Iron Sword");
		public static Item swordRusty = new Item(4, "Rusty Sword");
		public static Item swordPlat = new Item(5, "Platinum Sword");
		public static Item staffRegular = new Item(14, "Staff");
		public static Item bowShort = new Item(15, "Short Bow");

		//Shields
		public static Item shieldRound = new Item(6, "Round Shield");
		public static Item shieldSquare = new Item(7, "Square Shield");
		public static Item shieldKite = new Item(8, "Kite Shield");
		public static Item shieldPlatKite = new Item(9, "Platinum Kite Shield");

		public int id;
		public string name;

		public Item(int id, string name)
		{
			this.id = id;
			this.name = name;

			itemsList[id] = this;
		}
	}
}
