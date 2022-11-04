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
