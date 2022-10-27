using System;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class Tests
    {


        [Fact]
        public void OutOfBoundsInputValue()
        {
            Game game = new Game();

            bool flag = game.WriteCellContent(CellContent.X, 11, 12);

            Assert.False(flag);
        }


        [Fact]
        public void InvalidXValue()
        {
            Game game = new Game();
            GameUI ui = new GameUI(game);
;
            int x = ui.getXCoordinate(" ");

            Assert.Equal(-1, x);
        }

        [Fact]
        public void GoodXValue()
        {
            Game game = new Game();
            GameUI ui = new GameUI(game);

            int x = ui.getXCoordinate("a3");

            Assert.Equal(3, x);
        }


        [Fact]
        public void InvalidYValue()
        {
            Game game = new Game();
            GameUI ui = new GameUI(game);

            int y = ui.getYCoordinate(" ");

            Assert.Equal(-1, y);
        }

        [Fact]
        public void GoodYValue()
        {
            Game game = new Game();
            GameUI ui = new GameUI(game);

            int y = ui.getYCoordinate("d3");

            Assert.Equal(-1, y);
        }


        [Fact]
        public void GameOver()
        {

            Game game = new Game();

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 1] = CellContent.X;
            game.Table[2, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.True(game.Done);
        }


        [Fact]
        public void WinnerXGameOverDiagonal()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 1] = CellContent.X;
            game.Table[2, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverDiagonal()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.O;
            game.Table[1, 1] = CellContent.O;
            game.Table[2, 2] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }

        [Fact]
        public void WinnerXGameOverRow()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.X;
            game.Table[0, 1] = CellContent.X;
            game.Table[0, 2] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverRow()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.O;
            game.Table[0, 1] = CellContent.O;
            game.Table[0, 2] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }

        [Fact]
        public void WinnerXGameOverCol ()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.X;
            game.Table[1, 0] = CellContent.X;
            game.Table[2, 0] = CellContent.X;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.X, game.Winner);
        }

        [Fact]
        public void WinnerOGameOverCol()
        {
            Game game = new Game();

            game.Table[0, 0] = CellContent.O;
            game.Table[1, 0] = CellContent.O;
            game.Table[2, 0] = CellContent.O;

            game.CheckIsGameOver();

            Assert.Equal(CellContent.O, game.Winner);
        }

     

    }
}
