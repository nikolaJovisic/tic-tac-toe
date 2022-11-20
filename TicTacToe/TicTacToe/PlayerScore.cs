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
        private int sumOpponentScores;
        private int sumDefeatedOpponentScores;
        private int sumOpponentSOS;
        private int sumOpponentDOS;

        public int GamesPlayed { get => gamesPlayed; }
        public string Name { get => name; }


        public int Rank { set => rank = value; get => rank; }

        public int Points { set => points = value; get => points; }

        public int SumOpponentScores { set => sumOpponentScores = value; get => sumOpponentScores; }
        public int SumDefeatedOpponentScores { set => sumDefeatedOpponentScores = value; get => sumDefeatedOpponentScores; }
        public int SumOpponentSOS { set => sumOpponentSOS = value; get => sumOpponentSOS; }
        public int SumOpponentDOS { set => sumOpponentDOS = value; get => sumOpponentDOS; }

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
            snapshot.sumOpponentScores = sumOpponentScores;
            snapshot.sumDefeatedOpponentScores = sumDefeatedOpponentScores;
            snapshot.sumOpponentSOS = sumOpponentSOS;
            snapshot.sumOpponentDOS = sumOpponentDOS;
            return snapshot;
        }

    }
}
