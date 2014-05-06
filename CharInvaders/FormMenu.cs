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
        public int Theme;

        public FormMenu()
        {
            InitializeComponent();
            SoundCollection = new SoundCollection();
            shouldPlay = true;
            playThemeSong = true;
            Theme = 1;
            setTheme();
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
            FormHowTo fh = new FormHowTo(this);
            this.Hide();
            fh.Show();
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

        private void btnCredits_Click(object sender, EventArgs e)
        {
            FormCredits fc = new FormCredits(this);
            this.Hide();
            fc.Show();
        }
        public void setTheme() {
            if (Theme == 1) setTheme1();
            else setTheme2();
        }
        private void setTheme1() 
        {
            
        
        }
        
        private void setTheme2() 
        { 
            //ovoj tema za Martina
        }
    }
}
