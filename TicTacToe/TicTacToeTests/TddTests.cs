using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class TddTests
    {
       
        public List<PlayerScore> CreateMockScores()
        {
            PlayerScore p1 = new PlayerScore(10, 2, "p1", 10);
            PlayerScore p2 = new PlayerScore(20, 2, "p2", 20);

            List<PlayerScore> mockScores = new List<PlayerScore> { p1, p2 };

            return mockScores;
        }


        [Fact]
        public void UpdateSOSWinner()
        {
            PlayerScore p1 = new PlayerScore("p1");
            p1.Points = 100;
            PlayerScore p2 = new PlayerScore("p2");
            p2.Points = 10;
            Dictionary<string, PlayerScore> mockScore = new Dictionary<string, PlayerScore> { { p1.Name, p1 }, { p2.Name, p2 } };

            Ranking ranking = new Ranking(mockScore);

            ranking.GameFinished("p1", "p2", false);

            Assert.Equal(10, ranking.scores["p1"].SumOpponentScores);
        }




        //[Fact]
        //public void SortWithSOS()
        //{

        //    Ranking ranking = new Ranking();

        //    ranking.GameFinished("player1", "player2", false);

        //    var sortedScores = ranking.SortedScores();

        //    Assert.Equal("p2", sortedScores[0].Name);
        //    Assert.Equal("p2", sortedScores[0].Name);
            

        //}


    }
}
