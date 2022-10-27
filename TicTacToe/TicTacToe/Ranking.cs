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
                score = new PlayerScore();
            }
            score.GameFinishedUpdate(pointsDelta);
            scores[name] = score;
        }

        public void Serialize(string path)
        {
            Serialization.Serialize(scores, File.Open(path, FileMode.Create));
        }


        public void Display(string player1, string player2)
        {
            var ranking = scores.OrderBy(x => -x.Value.Points).ToList();
            var rank = 1;

            Console.WriteLine("HIGH SCORES");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" RANKING | NAME | POINTS | PLAYED |");
			Console.WriteLine();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (i != 0 && entry.Value.Points < ranking.ElementAt(i - 1).Value.Points) ++rank;
                if (entry.Key.Equals(player1))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-8}|{4,-8}| <----- Player1", rank, player1, entry.Value.Points/10, entry.Value.Points%10, entry.Value.GamesPlayed));
                }
                else if (entry.Key.Equals(player2))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-8}|{4,-8}| <----- Player2", rank, player2, entry.Value.Points/10, entry.Value.Points % 10, entry.Value.GamesPlayed));
                }
                else if (i < Console.WindowHeight - 6)
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2}.{3,-8}|{4,-8}|", rank, entry.Key, entry.Value.Points/10, entry.Value.Points % 10, entry.Value.GamesPlayed));
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
