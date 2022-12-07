using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    [Serializable]
    public class PlayerScore
    {
        int points = 0;
        int gamesPlayed = 0;
        int rank = -1;
        string name = "";
        private int sumOpponentScores = 0;
		public int Points { get => points; set => points = value; }
		public int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }
        public string Name { get => name; set => name = value; }
        public int Rank { set => rank = value; get => rank; }
		public int SumOpponentScores { get => sumOpponentScores; set => sumOpponentScores = value; }

		public PlayerScore(string name)
        {
            this.name = name;
        }

		public PlayerScore(int points, int gamesPlayed, string name, int sumOpponentScores)
		{
			this.points = points;
			this.gamesPlayed = gamesPlayed;
            this.name = name;
		}

		public void UpdatePlayerScore(int newPoints, PlayerScore opponent)
        {
            ++gamesPlayed;
            points += newPoints;
        }
    }
}
