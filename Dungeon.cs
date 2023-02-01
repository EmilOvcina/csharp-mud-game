using System;
namespace MUDProjekt
{
	public class Dungeon
	{
		public Room[] rumListe;
		public int id;

		public Dungeon(int id)
		{
			this.id = id;
			rumListe = new Room[32];
		}

		public void generateRoom()
		{
			//RoomType rt = RoomType.CITY;

			rumListe[0] = new Room(0, true, RoomType.START);
			rumListe[1] = new Room(1, true, RoomType.CITY);
			//rumListe[8] = new Room(8, RoomType.CITY);

			for (int i = 2; i < rumListe.Length; i++)
			{
				var r = new Random();
				//rumListe[i] = new Room(i, rt);
				if (r.NextDouble() >= 0.65)
				{
					if (r.NextDouble() <= 0.70)
						rumListe[i] = new Room(i, RoomType.ROAD);
					if (r.NextDouble() > 0.70)
						rumListe[i] = new Room(i, RoomType.CITY);
					if (r.NextDouble() > 0.75)
						rumListe[i] = new Room(i, RoomType.FIELD);
					if (r.NextDouble() > 0.80)
						rumListe[i] = new Room(i, RoomType.FORREST);
					if (r.NextDouble() > 0.90)
						rumListe[i] = new Room(i, RoomType.SAVANNA);
					if (r.NextDouble() > 0.96)
						rumListe[i] = new Room(i, RoomType.LOOT);
					if (r.NextDouble() > 0.98)
						rumListe[i] = new Room(i, RoomType.STORE);
				}
				else {
					if(rumListe[i - 1] != null)
						rumListe[i] = new Room(i, rumListe[i - 1].rt);
					else
						rumListe[i] = new Room(i, RoomType.FORREST);
						
				}
				//Console.WriteLine(rumListe[i].rt);
				System.Threading.Thread.Sleep(50);
			}
		}

		public void renderMap() 
		{
			for (int i = 2; i <= 31; i += 4) 
			{
				for (int y = 1; y <= 16; y += 4)
				{
					Screen.addRoom(i, y);
				}
			}

			for (int i = 0; i < 32; i++)
			{
				Screen.addToMap(i, 15, ' ');
			}

			//Render player
			int roomid = Player.getRoomId();
			int xp = roomid % 32;
			int yp = roomid;

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Screen.addToMap((i * 4) + 2, (j * 4) + 1, ' ');
				}
			}

			if (yp >= 24)
				yp = 10;
			else if (yp >= 15)
				yp = 7;
			else if (yp >= 8)
				yp = 4;
			else if (yp <= 7)
				yp = 1;
			Screen.addToMap(4 * xp + 2, yp, 'P');
		}
	}
}
