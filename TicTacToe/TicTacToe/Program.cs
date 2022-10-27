using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
			//Ranking r = new Ranking();
			//r.GameFinishedUpdate("a", 3);
			//r.GameFinishedUpdate("b", 3);
			//r.GameFinishedUpdate("q", 3);
			//r.GameFinishedUpdate("w", 3);
			//r.GameFinishedUpdate("e", 3);
			//r.GameFinishedUpdate("r", 3);
			//r.GameFinishedUpdate("t", 3);
			//r.GameFinishedUpdate("f", 3);
			//r.GameFinishedUpdate("b23", 3);
			//r.GameFinishedUpdate("a23", 3);
			//r.GameFinishedUpdate("q23", 3);
			//r.GameFinishedUpdate("w23", 3);
			//r.GameFinishedUpdate("e23", 3);
			//r.GameFinishedUpdate("r23", 3);
			//r.GameFinishedUpdate("t23", 3);
			//r.GameFinishedUpdate("f23", 3);
			//r.GameFinishedUpdate("b23", 3);
			//r.GameFinishedUpdate("a23", 3);
			//r.GameFinishedUpdate("q23", 3);
			//r.GameFinishedUpdate("w23", 3);
			//r.GameFinishedUpdate("e23", 3);
			//r.GameFinishedUpdate("r23", 3);
			//r.GameFinishedUpdate("t23", 3);
			//r.GameFinishedUpdate("f23", 3);
			//r.GameFinishedUpdate("b24", 3);
			//r.GameFinishedUpdate("a24", 3);
			//r.GameFinishedUpdate("q24", 3);
			//r.GameFinishedUpdate("w24", 3);
			//r.GameFinishedUpdate("e24", 3);
			//r.GameFinishedUpdate("r24", 3);
			//r.GameFinishedUpdate("t24", 3);
			//r.GameFinishedUpdate("f24", 3);
			//r.GameFinishedUpdate("q235", 3);
			//r.GameFinishedUpdate("w235", 3);
			//r.GameFinishedUpdate("e235", 3);
			//r.GameFinishedUpdate("r235", 3);
			//r.GameFinishedUpdate("t235", 3);
			//r.GameFinishedUpdate("f235", 3);
			//r.GameFinishedUpdate("b245", 3);
			//r.GameFinishedUpdate("a245", 3);
			//r.GameFinishedUpdate("q245", 3);
			//r.GameFinishedUpdate("w245", 3);
			//r.GameFinishedUpdate("e245", 3);
			//r.GameFinishedUpdate("r245", 3);
			//r.GameFinishedUpdate("t245", 3);
			//r.GameFinishedUpdate("f245", 3);
			//r.Display("a");
			//Console.Clear();
			//r.Display("f245");
			//Console.Clear();

			//r.Serialize("scores.bin");

			//var r2 = new Ranking("scores.bin");
			
			//r2.Display("b");


			Game game = new Game();
			GameUI UI = new GameUI(game);
			UI.Menu();
		}
    }
}
