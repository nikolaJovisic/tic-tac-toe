using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameUI
    {
        private Game game;
        public GameUI(Game game)
        {
            this.game = game;
        }

        public void Play()
        {
            while (!game.Done)
            {
                Turn();
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
            Console.WriteLine("Game finished, winner is {0}", CellContentToString(game.Winner));
        }

        private void Turn()
        {
            Console.WriteLine("{0} turn ->", CellContentToString(game.NextCellContent));
            PrintTable();

            bool isValid = false;
            int x = 0 , y = 0;


            while (!isValid)
            {
                Console.WriteLine("x coordinate:");
                try
                {
                    x = int.Parse(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
					Console.WriteLine("Invalid input");
                    continue;
                }

                Console.WriteLine("y coordinate:");
                try
                {
                    y = int.Parse(Console.ReadLine().Trim());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                
                isValid = game.WriteCellContent(game.NextCellContent, x - 1, y - 1);

                if (!isValid)
                {
					Console.WriteLine("Invalid input");
                }

            }
        }

        private void PrintTable()
        {
            for (int i = 0; i < game.TableDimension; ++i)
            {
                for (int j = 0; j < game.TableDimension; ++j)
                {
                    Console.Write("|{0}", CellContentToString(game.Table[i, j]));
                }
                Console.WriteLine("|");
                Console.Write("----");
                for (int j = 0; j < game.TableDimension - 2; ++j)
                {
                    Console.Write("---");
                }
                Console.WriteLine();
            }
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
