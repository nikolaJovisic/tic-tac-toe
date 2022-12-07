using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    [Serializable]
    class PlayerScore
    {
        int points = 0;
        int gamesPlayed = 0;
        int rank = -1;
        string name = "";
        private int sumOpponentScores;
		public int Points { get => points; }
		public int GamesPlayed { get => gamesPlayed; }
        public string Name { get => name; }
        public int Rank { set => rank = value; get => rank; }
		public int SumOpponentScores { get => sumOpponentScores; set => sumOpponentScores = value; }

		public PlayerScore(string name)
        {
            this.name = name;
        }

        public void UpdatePlayerScore(int newPoints, PlayerScore opponent)
        {
            ++gamesPlayed;
            points += newPoints;
            sumOpponentScores += opponent.Points;
        }
    }
}
