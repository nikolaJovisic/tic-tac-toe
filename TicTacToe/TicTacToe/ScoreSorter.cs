using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class ScoreSorter
    {
        public static List<PlayerScore> Sort(ICollection<PlayerScore> scores)
        {
            var ranking = scores.OrderBy(x => -x.Points).ThenBy(x => -x.SumOpponentScores).ThenBy(x => -x.SumDefeatedOpponentScores).ThenBy(x => -x.SumOpponentSOS);
            var rank = 1;
            IEnumerable<PlayerScore> retVal = new List<PlayerScore>();

            for (int i = 0; i < ranking.Count(); ++i)
            {
                var entry = ranking.ElementAt(i);
                if (i != 0 && entry.Points < ranking.ElementAt(i - 1).Points) ++rank;
                entry.Rank = rank;
                retVal = retVal.Append(entry);
            }

            return retVal.ToList();
        }
    }
}
