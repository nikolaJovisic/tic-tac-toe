using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace TicTacToe
{
    public class Ranking
    {
        public Dictionary<string, PlayerScore> scores;
        public Ranking()
        {
            scores = new Dictionary<string, PlayerScore>();
        }
        public Ranking (string path)
        {
            try
            {
                scores = Serialization.Deserialize<Dictionary<string, PlayerScore>>(File.Open(path, FileMode.Open));
            }
            catch (Exception)
            {
                scores = new Dictionary<string, PlayerScore>();
            }
        }

        public Ranking(Dictionary<string, PlayerScore> mockScores)
        {
            scores = mockScores;
        }

        public void Serialize(string path)
        {
            Serialization.Serialize(scores, File.Open(path, FileMode.Create));
        }

        public void GameFinished(string player1, string player2, bool isDraw)
		{
			int loserPoints = 0, winnerPoints = 0;

			GetPoints(isDraw, out loserPoints, out winnerPoints);

			PlayerScore score1 = GetCurrentScore(player1);
			PlayerScore score2 = GetCurrentScore(player2);

			var snapshotScore1 = score1;
			var snapshotScore2 = score2;

            if (isDraw)
            {
                score1.UpdatePlayerScoreDraw(winnerPoints, snapshotScore2);
                score2.UpdatePlayerScoreDraw(loserPoints, snapshotScore1);
            }
            else
			{
                score1.UpdatePlayerScoreWinner(winnerPoints, snapshotScore2);
                score2.UpdatePlayerScoreLoser(loserPoints, snapshotScore1);
            }
			
			scores[player1] = score1;
			scores[player2] = score2;
		}

		public void GetPoints(bool isDraw, out int loserPoints, out int winnerPoints)
		{
			if (isDraw)
			{
				loserPoints = 5;
				winnerPoints = 5;
			}
			else
			{
				loserPoints = 0;
				winnerPoints = 10;
			}
		}

		public PlayerScore GetCurrentScore(string player)
        {
            PlayerScore score;
            if(!scores.TryGetValue(player, out score))
            {
                score = new PlayerScore(player);
            }

            return score;
        }

        public List<PlayerScore> SortedScores()
		{
			var ranking = scores.Values.OrderBy(x => -x.Points).ThenBy(x => -x.SumOpponentScores).ThenBy(x => -x.SumDefeatedOpponentScores).ThenBy(x=> -x.SumOpponentSOS).ThenBy(x=> -x.SumOpponentDOS);
			var rank = 1;

			IEnumerable<PlayerScore> retVal = new List<PlayerScore>();

			SetRank(ranking, ref rank, ref retVal);

			return retVal.ToList();
		}

		private static void SetRank(IOrderedEnumerable<PlayerScore> ranking, ref int rank, ref IEnumerable<PlayerScore> retVal)
		{
			for (int i = 0; i < ranking.Count(); ++i)
			{
				var entry = ranking.ElementAt(i);
				if (i != 0 && entry.Points < ranking.ElementAt(i - 1).Points) ++rank;
				entry.Rank = rank;
				retVal = retVal.Append(entry);
			}
		}

		public void Display(string player1, string player2)
        {
            var ranking = SortedScores();
          
            Console.WriteLine("HIGH SCORES");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" RANKING | NAME | POINTS | PLAYED | SOS ");
			Console.WriteLine();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (entry.Name.Equals(player1))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}| {4,-8} <----- Player1", entry.Rank, player1, entry.Points / 10, entry.Points % 10, entry.GamesPlayed, entry.SumOpponentScores));
                }
                else if (entry.Name.Equals(player2))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}| {4,-8} <----- Player2", entry.Rank, player2, entry.Points / 10, entry.Points % 10, entry.GamesPlayed, entry.SumOpponentScores));
                }
                else if (i < Console.WindowHeight - 6)
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-6}|{4,-8}| {4,-8}", entry.Rank, entry.Name, entry.Points / 10, entry.Points % 10, entry.GamesPlayed, entry.SumOpponentScores));
                }
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
