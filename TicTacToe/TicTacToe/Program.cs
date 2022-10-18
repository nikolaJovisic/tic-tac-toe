using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            GameUI UI = new GameUI(game);
            UI.Play();
        }
    }
}
