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
            scores = Serialization.Deserialize<Dictionary<string, PlayerScore>>(File.Open(path, FileMode.Open));
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


        public void Display(string name = null)
        {
            var ranking = scores.OrderBy(x => -x.Value.Points).ToList();

            Console.WriteLine("HIGH SCORES");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" RANKING | NAME | POINTS | PLAYED |");
			Console.WriteLine();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (entry.Key.Equals(name))
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2,-8}|{3,-8}| <----- you", i + 1, name, entry.Value.Points, entry.Value.GamesPlayed));
                }
                else if (i < Console.WindowHeight - 7)
                {
                    Console.WriteLine(string.Format(" #{0,-7}|{1,-6}|{2,-8}|{3,-8}|", i + 1, name, entry.Key, entry.Value.Points, entry.Value.GamesPlayed));
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
