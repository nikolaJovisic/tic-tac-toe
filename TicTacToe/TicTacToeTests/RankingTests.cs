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

        [Fact]
        public void SortBySOS()
        {
            Ranking ranking = new Ranking();
            ranking.WinnedGameFinishedUpdate("p1", "p2");
            ranking.WinnedGameFinishedUpdate("p1", "p3");
            ranking.WinnedGameFinishedUpdate("p2", "p4");
            ranking.WinnedGameFinishedUpdate("p3", "p2");

            var sorted = ranking.SortedScores();

            Assert.Equal("p1", sorted[0].Name);
            Assert.Equal("p3", sorted[1].Name);
            Assert.Equal("p2", sorted[2].Name);
            Assert.Equal("p4", sorted[3].Name);
        }
    }
}
