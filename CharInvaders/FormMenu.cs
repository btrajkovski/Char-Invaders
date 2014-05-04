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
        public SoundCollection SoundCollection;
        public bool shouldPlay { set; get; }
        public bool playThemeSong;
        public FormMenu()
        {
            InitializeComponent();
            SoundCollection = new SoundCollection();
            shouldPlay = true;
            playThemeSong = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundCollection.PlayerThemeSong.Stop();
            FormGame fg = new FormGame(this);
            fg.Show();
            this.Hide();
        }
        
        private void btnHighScore_Click(object sender, EventArgs e)
        {
            FormHighScore fhs = new FormHighScore(this);
            this.Hide();
            fhs.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings(this);
            this.Hide();
            fs.Show();

        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            // TO DO
            // Implement FormHowTo
        }

        public void playMusic()
        {
            if (playThemeSong)
                SoundCollection.PlayerThemeSong.PlayLooping();
            else
                SoundCollection.PlayerThemeSong.Stop();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            playMusic();
        }
    }
}
