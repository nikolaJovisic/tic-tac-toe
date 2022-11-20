using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public struct PlayerScoreSnapshot
    {
        public int points;
        public int sumOpponentScores;
        public int sumDefeatedOpponentScores;
        public int sumOpponentSOS;
        public int sumOpponentDOS;
    }
}
