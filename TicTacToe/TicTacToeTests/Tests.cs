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
    }
}
