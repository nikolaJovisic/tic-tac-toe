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

        public int Points { get => points; }
        public int GamesPlayed { get => gamesPlayed; }
        public void GameFinishedUpdate(int pointsDelta)
        {
            ++gamesPlayed;
            points += pointsDelta;
        }
    }
}
