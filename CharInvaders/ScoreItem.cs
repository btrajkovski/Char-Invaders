using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    [Serializable]
    public class ScoreItem
    {
        public string playerName { set; get; }
        public int score { set; get; }

        public ScoreItem(string name, int score)
        {
            this.playerName = name;
            this.score = score;
        }
        public override string ToString()
        {
            return playerName + " " + score + "\n";
        }

    }
}
