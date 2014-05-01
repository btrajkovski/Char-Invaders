using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public  partial  class FormMenu : Form
    {
        public Highscores high { set; get; }
        public FormMenu()
        {
            InitializeComponent();
            lblScores.Hide();
            back.Hide();
            high = BinaryDeserializeScores();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            FormGame fg = new FormGame(this);
            fg.Show();
            this.Hide();
        }
        public void addScore(Score sc)
        {
            if(sc != null)
            high.addHighscore(sc);
            BinarySerializeScores(high);
        }
        private static void BinarySerializeScores(Highscores HS)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using (FileStream str = File.Open(path + "\\HighScoresCharInvaders.hs", FileMode.OpenOrCreate))
            {
                File.SetAttributes(path + "\\HighScoresCharInvaders.hs", File.GetAttributes(path + "\\HighScoresCharInvaders.hs") | FileAttributes.Hidden);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, HS);
            }
        }
        private static Highscores BinaryDeserializeScores()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Highscores HS = null;
            try
            {

                using (FileStream str = File.OpenRead(path + "\\HighScoresCharInvaders.hs"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    HS = (Highscores)bf.Deserialize(str);
                }

                //File.Delete(path + "\\HighScoresCharInvaders.hs");

                return HS;
            }
            catch (FileNotFoundException)
            {
                return new Highscores();
            }
            
        }



        private void btnHighScore_Click(object sender, EventArgs e)
        {
            back.Show();
            btnCredits.Hide();
            btnHighScore.Hide();
            btnPlay.Hide();
            lblScores.Text = high.ToString();
            
            lblScores.Show();
        }

        private void back_Click(object sender, EventArgs e)
        {
            btnPlay.Show();
            btnHighScore.Show();
            btnCredits.Show();
            lblScores.Hide();
            back.Hide();
        }


    }
}
