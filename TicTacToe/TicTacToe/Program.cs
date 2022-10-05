using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(3);
            GameUI UI = new GameUI(game);
            UI.Play();
        }
    }
}
