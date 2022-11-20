using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class RankingTests
    {
        [Fact]
        public void Basic()
        {
            Ranking ranking = new Ranking();
            ranking.WinnedGameFinishedUpdate("p2", "p1");
            var sorted = ranking.SortedScores();
            Assert.Equal("p2", sorted[0].Name);
            Assert.Equal("p1", sorted[1].Name);
        }
    }
}
