using System;

namespace MUDProjekt
{
	class MainClass
	{
		public static int WIDTH = 32, HEIGHT = 16;

		public Screen s;
		public Game g;

		public MainClass()
		{
			s = new Screen();
			g = new Game();
		}

		public void game()
		{
			Console.WriteLine("Welcome to the game!");
			Console.WriteLine("Main Menu commands: ");
			Console.WriteLine("Start");
			Console.WriteLine("Exit \n");

			string input = Console.ReadLine();

			switch (input.ToLower()) 
			{
				case "start":
					Console.WriteLine("Game started!\n\n");
					g.playIntro();
					g.chooseClass();
					g.playGame();
					break;

				case "exit":
					Environment.Exit(0);
					break;

				default:
					Console.WriteLine("That command is not valid.");
					game();
					break;
			}
		}

		public static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.White;
			var m = new MainClass();
			m.game();
		}
	}
}