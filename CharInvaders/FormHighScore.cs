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
    public partial class FormHighScore : Form
    {
        private Form menuForm;
        public Highscores high { set; get; }

        public FormHighScore(Form menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            high = BinaryDeserializeScores();
            updateHighScore();
            this.Location = menuForm.Location;
        }

        public void addScore(Score sc)
        {
            if (sc != null)
                high.addHighscore(sc);
            BinarySerializeScores(high);
            updateHighScore();
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

                return HS;
            }
            catch (FileNotFoundException)
            {
                return new Highscores();
            }

        }

        public bool checkIfHighscore(int sc)
        {
            return high.checkScore(sc);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Location = this.Location;
            menuForm.Show();
        }

        private void updateHighScore()
        {
            lblScores.Text = high.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to delete all the high scores?", "Confirm delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                try
                {
                    File.Delete(path + "\\HighScoresCharInvaders.hs");
                }
                catch (Exception)
                {
                    // Do nothing
                }
                finally
                {
                    lblScores.Text = "";
                    high = new Highscores();
                }
            }
        }

        private void FormHighScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
