using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class Highscores
    {
        public List<Score> highScores;

        public Highscores()
        {
            highScores = new List<Score>();
        }
        public void addHighscore(Score sc)
        {
            highScores.Add(sc);
            highScores = highScores.OrderByDescending(x => x.score).ToList();
            if (highScores.Count > 5)
                highScores.RemoveAt(5);
        }
        public override string ToString()
        {
            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (Score s in highScores)
            {
                sb.Append(i + ". " + s);
                i++;
            }
            return sb.ToString();
        }
    }
}
