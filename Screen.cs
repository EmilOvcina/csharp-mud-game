using System;
namespace MUDProjekt
{

	public class Screen
	{
		public static char[] map;
		public static char lb = '╰';
		public static char rb = '╯';
		public static char lt = '╭';
		public static char rt = '╮';

		public Screen()
		{
			map = new char[MainClass.WIDTH * MainClass.HEIGHT];
			for (int i = 0; i < map.Length; i++)
				map[i] = ' ';
		}

		public static void addToMap(int x, int y, char c)
		{
			map[x + y * MainClass.WIDTH] = c;
		}

		public static void addRoom(int x, int y)
		{
			addToMap(x - 1, y, '|');
			addToMap(x + 1, y, '|');
			addToMap(x, y + 2, '|');
			addToMap(x, y - 1, '-');
			addToMap(x + 2, y, '-');
			addToMap(x, y + 1, '-');

			addToMap(x - 1, y - 1, lt);
			addToMap(x + 1, y - 1, rt);
			addToMap(x - 1, y + 1, lb);
			addToMap(x + 1, y + 1, rb);
		}
	}
}
