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

            Console.WriteLine("ranking, name, points, played");

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (entry.Key.Equals(name))
                {
                    Console.WriteLine(string.Format("{0}, {1}, {2}, {3} <------- you", i + 1, name, entry.Value.Points, entry.Value.GamesPlayed));
                }
                else if (i < Console.WindowHeight - 4)
                {
                    Console.WriteLine(string.Format("{0}, {1}, {2}, {3}", i + 1, entry.Key, entry.Value.Points, entry.Value.GamesPlayed));
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
