using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharInvaders
{
    [Serializable]
    public class HighScores
    {
        public List<ScoreItem> highScores;

        public HighScores()
        {
            highScores = new List<ScoreItem>();
        }
        public void addHighscore(ScoreItem sc)
        {
            highScores.Add(sc);
            highScores = highScores.OrderByDescending(x => x.score).ToList();
            if (highScores.Count > 5)
                highScores.RemoveAt(5);
        }
        public bool checkScore(int sc)
        { 
            if(highScores.Count >= 5 && sc > highScores[4].score) return true;
            if (highScores.Count < 5) return true;
            return false;
        }

        public override string ToString()
        {
            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (ScoreItem s in highScores)
            {
                sb.Append(i + ". " + s);
                i++;
            }
            return sb.ToString();
        }
    }
}
