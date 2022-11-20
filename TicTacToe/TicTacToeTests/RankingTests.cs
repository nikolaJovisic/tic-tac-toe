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

        [Fact]
        public void SOSSort()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            s1.SumOpponentScores = 0;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 10;
            s2.SumOpponentScores = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            var sortedScores = ScoreSorter.Sort(scores.Values);

            Assert.Equal("p2", sortedScores[0].Name);
            Assert.Equal("p1", sortedScores[1].Name);
        }

        [Fact]
        public void SDOSUpdate()
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
            Assert.Equal(20, rankingScores["p1"].SumDefeatedOpponentScores);
        }

        [Fact]
        public void SDOSSort()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            s1.SumOpponentScores = 10;
            s1.SumDefeatedOpponentScores = 0;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 10;
            s2.SumOpponentScores = 10;
            s2.SumDefeatedOpponentScores = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            var sortedScores = ScoreSorter.Sort(scores.Values);

            Assert.Equal("p2", sortedScores[0].Name);
            Assert.Equal("p1", sortedScores[1].Name);
        }

        [Fact]
        public void SOSOSUpdate()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 20;
            s2.SumOpponentScores = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            Ranking ranking = new Ranking(scores);

            ranking.FinishGameWinnerLoser("p1", "p2");

            var rankingScores = ranking.Scores;
            Assert.Equal(10, rankingScores["p1"].SumOpponentSOS);
        }

        [Fact]
        public void SOSOSSort()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            s1.SumOpponentScores = 10;
            s1.SumDefeatedOpponentScores = 10;
            s1.SumOpponentSOS = 0;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 10;
            s2.SumOpponentScores = 10;
            s2.SumDefeatedOpponentScores = 10;
            s2.SumOpponentSOS = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            var sortedScores = ScoreSorter.Sort(scores.Values);

            Assert.Equal("p2", sortedScores[0].Name);
            Assert.Equal("p1", sortedScores[1].Name);
        }

        [Fact]
        public void SODOSUpdate()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 20;
            s2.SumDefeatedOpponentScores = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            Ranking ranking = new Ranking(scores);

            ranking.FinishGameWinnerLoser("p1", "p2");

            var rankingScores = ranking.Scores;
            Assert.Equal(10, rankingScores["p1"].SumOpponentDOS);
        }

        [Fact]
        public void SODOSSort()
        {
            string p1 = "p1";
            string p2 = "p2";
            Dictionary<string, PlayerScore> scores = new Dictionary<string, PlayerScore>();

            PlayerScore s1 = new PlayerScore(p1);
            s1.Points = 10;
            s1.SumOpponentScores = 10;
            s1.SumDefeatedOpponentScores = 10;
            s1.SumOpponentSOS = 10;
            s1.SumOpponentDOS = 0;
            PlayerScore s2 = new PlayerScore(p2);
            s2.Points = 10;
            s2.SumOpponentScores = 10;
            s2.SumDefeatedOpponentScores = 10;
            s2.SumOpponentSOS = 10;
            s2.SumOpponentDOS = 10;

            scores.Add(p1, s1);
            scores.Add(p2, s2);

            var sortedScores = ScoreSorter.Sort(scores.Values);

            Assert.Equal("p2", sortedScores[0].Name);
            Assert.Equal("p1", sortedScores[1].Name);
        }

    }
}
