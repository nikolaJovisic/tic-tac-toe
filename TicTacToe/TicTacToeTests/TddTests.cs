using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
	public class TddTests
	{

		public Dictionary<string, PlayerScore> CreateMockScores()
		{
			PlayerScore p1 = new PlayerScore(10, 2, "p1", 20, 0);
			PlayerScore p2 = new PlayerScore(10, 2, "p2", 200, 200);

			Dictionary<string, PlayerScore> mockScores = new Dictionary<string, PlayerScore> { { p1.Name, p1 }, { p2.Name, p2 } };

			return mockScores;
		}

		[Fact]
		public void GetPointsWinnerLoser()
		{
			Ranking ranking = new Ranking();

			int loser = 0;
			int winner = 0;

			ranking.GetPoints(false, out loser, out winner);

			Assert.Equal(10, winner);
			Assert.Equal(0, loser);
		}

		[Fact]
		public void GetPointsDraw()
		{
			Ranking ranking = new Ranking();

			int loser = 0;
			int winner = 0;

			ranking.GetPoints(true, out loser, out winner);

			Assert.Equal(5, winner);
			Assert.Equal(5, loser);
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

		[Fact]
		public void UpdateSOSDraw()
		{
			PlayerScore p1 = new PlayerScore("p1");
			p1.Points = 5;
			PlayerScore p2 = new PlayerScore("p2");
			p2.Points = 5;
			Dictionary<string, PlayerScore> mockScore = new Dictionary<string, PlayerScore> { { p1.Name, p1 }, { p2.Name, p2 } };

			Ranking ranking = new Ranking(mockScore);

			ranking.GameFinished("p1", "p2", false);

			Assert.Equal(5, ranking.scores["p1"].SumOpponentScores);
		}


		// lookup values in CreateMockScores

		[Fact]
		public void SortWithSOS()
		{
			Dictionary<string, PlayerScore> mockScores = CreateMockScores();

			Ranking ranking = new Ranking(mockScores);

			var sortedScores = ranking.SortedScores();

			Assert.Equal("p2", sortedScores[0].Name);
			Assert.Equal("p1", sortedScores[1].Name);

		}

		[Fact]
		public void UpdateSDOS()
		{
			PlayerScore p1 = new PlayerScore("p1");
			p1.Points = 100;
			PlayerScore p2 = new PlayerScore("p2");
			p2.Points = 10;
			Dictionary<string, PlayerScore> mockScore = new Dictionary<string, PlayerScore> { { p1.Name, p1 }, { p2.Name, p2 } };

			Ranking ranking = new Ranking(mockScore);

			ranking.GameFinished("p1", "p2", false);

			Assert.Equal(10, ranking.scores["p1"].SumDefeatedOpponentScores);
		}

		[Fact]
		public void SortWithSDOS()
		{
			Dictionary<string, PlayerScore> mockScores = CreateMockScores();
			mockScores["p2"].SumOpponentScores = 20;

			Ranking ranking = new Ranking(mockScores);

			var sortedScores = ranking.SortedScores();

			Assert.Equal("p2", sortedScores[0].Name);
			Assert.Equal("p1", sortedScores[1].Name);

		}


	}
}
