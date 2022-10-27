using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameUI
    {
        private Game game;
        private Ranking ranking = new Ranking("scores.bin");

        public GameUI(Game game)
        {
            this.game = game;
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine(" X vs O - THE GAME ");
                Console.WriteLine("-------------------");
                Console.WriteLine(" 1. NEW GAME \n 2. HIGHSCORES \n 3. REMATCH ");
                int option = 0;

                try
                {
                    option = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }

                switch (option)
                {
                    case 1:
                        GetPlayerInfo();
                        Play();
                        break;

                    case 2:
                        ShowHighscores();
                        break;

                    case 3:
                        Rematch();
                        break;

                    default:
                        break;
                }

            }
        }

		private void Rematch()
		{
            Player temp = game.Player1;
            game.Player1 = game.Player2;
            game.Player2 = temp;
            game.Clean();
         
            Play();
        }

		private void ShowHighscores()
		{
            ranking.Display(game.Player1.Name, game.Player2.Name);
        }

        private void GetPlayerInfo()
        {
			Console.WriteLine("Enter name of Player 1 (X): ");
            game.Player1.Name = Console.ReadLine();
            game.Player1.Shape = CellContent.X;

			Console.WriteLine("Enter name of Player 2 (O): ");
            game.Player2.Name = Console.ReadLine();
            game.Player2.Shape = CellContent.O;

        }

        public void Play()
        {
            game.Clean();
            string name = game.Player2.Name;

            while (!game.Done)
            {
                name = name == game.Player2.Name ? game.Player1.Name : game.Player2.Name; 
                Turn(name);
                IsGameOver();
            }
            End();
        }

        private void IsGameOver()
        {
           game.CheckIsGameOver();
        }

        private void End()
        {
            PrintTable();
            string winner = "";

			if (game.Player1.Shape == game.Winner)
			{
				winner = game.Player1.Name;
                ranking.GameFinishedUpdate(game.Player1.Name, 10);
                ranking.GameFinishedUpdate(game.Player2.Name, 0);
			}
			else if (game.Player2.Shape == game.Winner)
            {
				winner = game.Player2.Name;
                ranking.GameFinishedUpdate(game.Player2.Name, 10);
                ranking.GameFinishedUpdate(game.Player1.Name, 0);
			}
            else
            {
                winner = "not decided, it is a draw.";
                ranking.GameFinishedUpdate(game.Player2.Name, 5);
                ranking.GameFinishedUpdate(game.Player1.Name, 5);
            }

			Console.WriteLine("Game finished, winner is {0}", winner);
   
            ranking.Serialize("scores.bin");
        }

  

        private void Turn(string player)
        {
            Console.WriteLine("{0} ({1}) turn ->", CellContentToString(game.NextCellContent), player);
            PrintTable();

            bool isValid = false;
            int x = 0 , y = 0;


            while (!isValid)
            {
                Console.WriteLine("Input (format a2, b3 etc.):");

                string input = Console.ReadLine();

                x = getXCoordinate(input);
                if (x == -1) continue;

                y = getYCoordinate(input);
                if (y == -1) continue;

                isValid = game.WriteCellContent(game.NextCellContent, x - 1, y - 1);

                if (!isValid)
                {
					Console.WriteLine("Invalid input");
                }

            }
        }

        public int getXCoordinate(string input)
        {
            int x = -1;

            try
            {
                x = int.Parse(input.Substring(1));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
                x = - 1;
            }

            return x;
        }

        public int getYCoordinate(string input)
        {
            int y = -1;

            y = (char)input[0] - 'a' + 1;

            if (Math.Abs(y) > game.TableDimension)
            {
                y = -1;
                Console.WriteLine("Invalid input");
            }

            return y;
        }


        private void PrintTable()
        {
            Console.Write("  ");
            for (int i = 0; i < game.TableDimension; ++i)
            {
                Console.Write(" {0}", GetLetter(i));
            }
			Console.WriteLine();
        
            for (int j = 0; j < game.TableDimension - 1; ++j)
            {
				if (j == 0) Console.Write("  -");

                Console.Write("---");
            }

            Console.WriteLine();
            for (int i = 0; i < game.TableDimension; ++i)
            {
                Console.Write("{0} ", i + 1);
                for (int j = 0; j < game.TableDimension; ++j)
                {
                    Console.Write("|{0}", CellContentToString(game.Table[i, j]));
                }
                Console.WriteLine("|");
                Console.Write("  ----");
                for (int j = 0; j < game.TableDimension - 2; ++j)
                {
                    Console.Write("---");
                }
                Console.WriteLine();
            }
        }

        public char GetLetter(int value)
        {
            return (char)('a' + value);
        }

        private string CellContentToString(CellContent cellContent)
        {
            return cellContent switch
            {
                CellContent.X => "X",
                CellContent.O => "O",
                CellContent.empty => " ",
                _ => throw new Exception("Table not initialized!"),
            };
        }

    }
}
