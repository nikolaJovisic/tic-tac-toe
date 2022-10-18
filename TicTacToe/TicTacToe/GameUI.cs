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
                Console.WriteLine("Input (format a2, b3 etc.):");
                string input = Console.ReadLine();
                y = (char)input[0] - 'a' + 1;
                try
                {
                    x = int.Parse(input.Substring(1));
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
            Console.Write("| ");
            for (int i = 0; i < game.TableDimension; ++i)
            {
                Console.Write("|{0}", GetLetter(i));
            }
            Console.WriteLine("|");
            Console.Write("----");
            for (int j = 0; j < game.TableDimension - 2; ++j)
            {
                Console.Write("---");
            }
            Console.WriteLine();
            for (int i = 0; i < game.TableDimension; ++i)
            {
                Console.Write("|{0}", i + 1);
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
