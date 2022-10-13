using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class Tests
    {
        [Fact]
        public void TooSmallDimensionThrowsException()
        {
            Assert.Throws<Exception>(() => new Game(2));
        }


        [Fact]
        public void OutOfBoundsInputValue()
        {
            Game game = new Game(3);

            bool flag = game.WriteCellContent(CellContent.X, 11, 12);

            Assert.False(flag);
        }

        [Fact]
        public void GameOver()
        {

            Game game = new Game(3);

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 1] = CellContent.X;
            game.Table[2, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.True(game.Done);
        }


        [Fact]
        public void WinnerXGameOverDiagonal()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 1] = CellContent.X;
            game.Table[2, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverDiagonal()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.O;
            game.Table[1, 1] = CellContent.O;
            game.Table[2, 2] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }

        [Fact]
        public void WinnerXGameOverRow()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.X;
            game.Table[0, 1] = CellContent.X;
            game.Table[0, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverRow()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.O;
            game.Table[0, 1] = CellContent.O;
            game.Table[0, 2] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }

        [Fact]
        public void WinnerXGameOverCol ()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 0] = CellContent.X;
            game.Table[2, 0] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverCol()
        {
            Game game = new Game(3);

            game.Table[0, 0] = CellContent.O;
            game.Table[1, 0] = CellContent.O;
            game.Table[2, 0] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }


    }
}
