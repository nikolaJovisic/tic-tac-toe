using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace TicTacToe
{
    public class Ranking
    {
        public Dictionary<string, PlayerScore> Scores { get;  }
        public Ranking()
        {
            Scores = new Dictionary<string, PlayerScore>();
        }
        public Ranking (string path)
        {
            try
            {
                Scores = Serialization.Deserialize<Dictionary<string, PlayerScore>>(File.Open(path, FileMode.Open));
            }
            catch (Exception)
            {
                Scores = new Dictionary<string, PlayerScore>();
            }
        }

        public Ranking (Dictionary<string, PlayerScore> scores)
        {
            this.Scores = scores;
        }

        public void FinishGameDraw(string player1, string player2)
        {
            var score1 = GetPlayerScore(player1);
            var score2 = GetPlayerScore(player2);
            var snapshot1 = score1.GetSnapshot();
            var snapshot2 = score2.GetSnapshot();
            UpdateDrawPlayerScore(score1, snapshot2);
            UpdateDrawPlayerScore(score2, snapshot1);
            Scores[player1] = score1;
            Scores[player2] = score2;
        }


        public void FinishGameWinnerLoser(string winner, string loser)
        {
            var winnerScore = GetPlayerScore(winner);
            var loserScore = GetPlayerScore(loser);
            var winnerSnapshot = winnerScore.GetSnapshot();
            var loserSnapshot = loserScore.GetSnapshot();
            UpdateWinnerScore(winnerScore, loserSnapshot);
            UpdateLoserScore(loserScore, winnerSnapshot);
            Scores[winner] = winnerScore;
            Scores[loser] = loserScore;
        }

        private PlayerScore GetPlayerScore(string player)
        {
            PlayerScore score;
            if (!Scores.TryGetValue(player, out score))
            {
                score = new PlayerScore(player);
            }
            return score;
        }

        private void UpdateWinnerScore(PlayerScore score, PlayerScoreSnapshot opponentSnapshot)
        {
            score.GameFinished();
            score.Points += 10;
            score.SumOpponentScores += opponentSnapshot.points;
            score.SumDefeatedOpponentScores += opponentSnapshot.points;
            score.SumOpponentSOS += opponentSnapshot.sumOpponentScores;
            score.SumOpponentDOS += opponentSnapshot.sumDefeatedOpponentScores;
        }

        private void UpdateLoserScore(PlayerScore score, PlayerScoreSnapshot opponentSnapshot)
        {
            score.GameFinished();
            score.SumOpponentScores += opponentSnapshot.points;
            score.SumOpponentSOS += opponentSnapshot.sumOpponentScores;
            score.SumOpponentDOS += opponentSnapshot.sumDefeatedOpponentScores;
        }

        private void UpdateDrawPlayerScore(PlayerScore score, PlayerScoreSnapshot opponentSnapshot)
        {
            score.GameFinished();
            score.Points += 5;
            score.SumOpponentScores += opponentSnapshot.points;
            score.SumOpponentSOS += opponentSnapshot.sumOpponentScores;
            score.SumOpponentDOS += opponentSnapshot.sumDefeatedOpponentScores;
        }

        public void Serialize(string path)
        {
            Serialization.Serialize(Scores, File.Open(path, FileMode.Create));
        }

        public List<PlayerScore> SortedScores()
        {
            return ScoreSorter.Sort(Scores.Values);
        }


        public void Display(string player1, string player2)
        {
            var ranking = SortedScores();
          

            Console.WriteLine("HIGH SCORES");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" RANKING | NAME | POINTS | PLAYED |");
			Console.WriteLine();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (entry.Name.Equals(player1))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}| <----- Player1", entry.Rank, player1, entry.Points / 10, entry.Points % 10, entry.GamesPlayed));
                }
                else if (entry.Name.Equals(player2))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}| <----- Player2", entry.Rank, player2, entry.Points / 10, entry.Points % 10, entry.GamesPlayed));
                }
                else if (i < Console.WindowHeight - 6)
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}|", entry.Rank, entry.Name, entry.Points / 10, entry.Points % 10, entry.GamesPlayed));
                }
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
