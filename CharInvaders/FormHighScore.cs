﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CharInvaders
{
    public partial class FormHighScore : Form
    {
        private Form menuForm;
        public HighScores HighScore { set; get; }

        public FormHighScore(Form menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
            this.btnClear1.SetImages(Properties.Resources.clear_button, Properties.Resources.clear_button2);
            HighScore = BinaryDeserializeScores();
            updateHighScore();
        }

        public void addScore(ScoreItem sc)
        {
            if (sc != null)
                HighScore.addHighscore(sc);
            BinarySerializeScores(HighScore);
            updateHighScore();
        }

        private static void BinarySerializeScores(HighScores HS)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            
            using (FileStream str = File.Open(path + "\\HighScoresCharInvaders.hs", FileMode.OpenOrCreate))
            {
                File.SetAttributes(path + "\\HighScoresCharInvaders.hs", File.GetAttributes(path + "\\HighScoresCharInvaders.hs") | FileAttributes.Hidden);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(str, HS);
            }
        }


        private static HighScores BinaryDeserializeScores()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            HighScores HS = null;
            try
            {

                using (FileStream str = File.OpenRead(path + "\\HighScoresCharInvaders.hs"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        HS = (HighScores)bf.Deserialize(str);
                    }
                    catch (Exception)
                    {
                        return new HighScores();
                    }
                }

                return HS;
            }
            catch (FileNotFoundException)
            {
                return new HighScores();
            }

        }

        public bool checkIfHighscore(int sc)
        {
            return HighScore.checkScore(sc);
        }

        private void updateHighScore()
        {
            lblScores.Text = HighScore.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to delete all scores?", "Confirm Delete", MessageBoxButtons.YesNo);
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
                    HighScore = new HighScores();
                }
            }
        }

        private void FormHighScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Show();
        }
    }
}
