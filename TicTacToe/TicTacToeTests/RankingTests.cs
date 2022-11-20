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
            ranking.FinishGameWinnerLoser("p2", "p1");
            var sorted = ranking.SortedScores();
            Assert.Equal("p2", sorted[0].Name);
            Assert.Equal("p1", sorted[1].Name);
        }

        [Fact]
        public void SOSUpdate()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 20;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            Ranking ranking = new Ranking(scores);

            ranking.FinishGameWinnerLoser("p1", "p2");

            var rankingScores = ranking.Scores;
            Assert.Equal(20, rankingScores["p1"].SumOpponentScores);
        }

    }
}
