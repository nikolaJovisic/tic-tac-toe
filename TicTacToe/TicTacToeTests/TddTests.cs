using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
	public class TddTests
	{

        [Fact]
        public void BasicVersion()
        {
            Game game = new Game();

            bool flag = game.WriteCellContent(CellContent.X, 11, 12);

            Assert.False(flag);
        }


    }
}
