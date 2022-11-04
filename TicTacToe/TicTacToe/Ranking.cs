using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace TicTacToe
{
    class Ranking
    {
        Dictionary<string, PlayerScore> scores;
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
        public void GameFinishedUpdate(string name, int pointsDelta)
        {
            PlayerScore score;
            if(!scores.TryGetValue(name, out score))
            {
                score = new PlayerScore(name);
            }
            score.GameFinishedUpdate(pointsDelta);
            scores[name] = score;
        }

        public void Serialize(string path)
        {
            Serialization.Serialize(scores, File.Open(path, FileMode.Create));
        }

        private IEnumerable<PlayerScore> SortedScores(string player1, string player2)
        {
            var ranking = scores.Values.OrderBy(x => -x.Points);
            var rank = 1;
            IEnumerable<PlayerScore> retVal = new List<PlayerScore>();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (i != 0 && entry.Points < ranking.ElementAt(i - 1).Points) ++rank;
                entry.Rank = rank;
                retVal = retVal.Append(entry);
            }

            return retVal;
        }


        public void Display(string player1, string player2)
        {
            var ranking = SortedScores(player1, player2);
          

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
