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
        int rank = -1;

        public int GamesPlayed { get => gamesPlayed; }
        public string Name { get => name; }


        public int Rank { set => rank = value; get => rank; }

        public int Points { set => points = value; get => points; }

        public PlayerScore(string name)
        {
            this.name = name;
        }
        public void GameFinished()
        {
            ++gamesPlayed;
        }

        public PlayerScoreSnapshot GetSnapshot()
        {
            PlayerScoreSnapshot snapshot;
            snapshot.points = points;
            return snapshot;
        }

    }
}
