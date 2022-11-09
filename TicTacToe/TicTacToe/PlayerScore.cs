using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    [Serializable]
    public class PlayerScore
    {
        string name = "";
        int points = 0;
        int gamesPlayed = 0;
        int sumOpponentScores = 0;
        int sumDefeatedOpponentScores = 0;
        int sumOpponentSOS = 0;
        int sumOpponentDOS = 0;
        int rank = -1;

        public int Points { get => points; }
        public int GamesPlayed { get => gamesPlayed; }
        public string Name { get => name; }


        public int Rank { set => rank = value; get => rank; }

        public PlayerScore(string name)
        {
            this.name = name;
        }
        public void GameFinishedUpdate(int pointsDelta)
        {
            ++gamesPlayed;
            points += pointsDelta;
        }
    }
}
