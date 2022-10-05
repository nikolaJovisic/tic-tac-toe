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
            }
            End();
        }

        private void End()
        {
            Console.WriteLine("Game finished, winner is {0}", CellContentToString(game.Winner));
        }

        private void Turn()
        {
            Console.WriteLine("{0} turn ->", CellContentToString(game.NextCellContent));
            PrintTable();
            Console.WriteLine("x coordinate:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("y coordinate:");
            int y = int.Parse(Console.ReadLine());
            game.WriteCellContent(game.NextCellContent, x, y);
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
