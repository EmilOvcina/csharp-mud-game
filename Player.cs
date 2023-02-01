using System;
using System.Collections.Generic;
namespace MUDProjekt
{
	public static class Player
	{
		public static List<Item> inv = new List<Item>();

		public static int RoomID;
		public static int pClass;
		public static int health;
		public static int attack;
		public static int speed;
		public static int defence;

		public static void setRoomId(int id)
		{
			RoomID = id;
		}

		public static int getRoomId()
		{
			return RoomID;
		}

		public static void addItemToInv(Item item)
		{
			inv.Add(item);
		}

		public static void removeItemFromInv(Item item)
		{
			inv.Remove(item);
		}

		public static void displayInv()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.Write("--");
			}
			Console.Write(" Player Inventory ");
			for (int i = 0; i < 10; i++)
			{
				Console.Write("--");
			}
			Console.Write("\n");
			for (int i = 0; i < inv.ToArray().Length; i++)
			{
				Console.Write(inv[i].name);
				if (i % 4 == 0 && i != 0)
					Console.Write("\n");
				else
					Console.Write(", ");
			}
			Console.Write("\n");
			for (int i = 0; i < 29; i++)
			{
				Console.Write("--");
			}
			Console.Write("\n");
		}
	}
}
