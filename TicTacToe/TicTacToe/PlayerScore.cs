﻿using System;

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
        private int sumDefeatedOpponentScores = 0;
        public int Points { get => points; set => points = value; }
        public int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }
        public string Name { get => name; set => name = value; }
        public int Rank { set => rank = value; get => rank; }
        public int SumOpponentScores { get => sumOpponentScores; set => sumOpponentScores = value; }
		public int SumDefeatedOpponentScores { get => sumDefeatedOpponentScores; set => sumDefeatedOpponentScores = value; }

		public PlayerScore(string name)
        {
            this.name = name;
        }

        public PlayerScore(int points, int gamesPlayed, string name, int sumOpponentScores, int sumDefeatedOpponentScores)
        {
            this.points = points;
            this.gamesPlayed = gamesPlayed;
            this.name = name;
            this.sumOpponentScores = sumOpponentScores;
            this.sumDefeatedOpponentScores = sumDefeatedOpponentScores;
        }

        public void UpdatePlayerScoreWinner(int newPoints, PlayerScore opponent)
        {
            ++gamesPlayed;
            points += newPoints;
            sumOpponentScores += opponent.Points;
            sumDefeatedOpponentScores += opponent.Points;
            
        }

        public void UpdatePlayerScoreLoser(int newPoints, PlayerScore opponent)
        {
            ++gamesPlayed;
            points += newPoints;
            sumOpponentScores += opponent.Points;
            sumDefeatedOpponentScores += opponent.Points;

        }

        public void UpdatePlayerScoreDraw(int newPoints, PlayerScore opponent)
        {
            ++gamesPlayed;
            points += newPoints;
            sumOpponentScores += opponent.Points;
            sumDefeatedOpponentScores += opponent.Points / 2;

        }
    }
}