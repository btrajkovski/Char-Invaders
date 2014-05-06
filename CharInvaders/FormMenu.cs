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
            Image i = Properties.Resources.background2;
            this.BackgroundImage = i;

            Image play_img = Properties.Resources.rsz_play;
            btnPlay.Image = play_img;
            btnPlay.Width = 250;
            btnPlay.Height = 90;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.SizeMode = PictureBoxSizeMode.StretchImage;

            Image highscore_img = Properties.Resources.rsz_highscore;
            btnHighScore.Image = highscore_img;
            btnHighScore.Width = 250;
            btnHighScore.Height = 90;
            btnHighScore.BackColor = Color.Transparent;
            btnHighScore.SizeMode = PictureBoxSizeMode.StretchImage;

            Image settings_img = Properties.Resources.rsz_settings;
            btnSettings.Image = settings_img;
            btnSettings.Width = 250;
            btnSettings.Height = 90;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.SizeMode = PictureBoxSizeMode.StretchImage;

            Image howtoplay_img = Properties.Resources.rsz_howtoplay;
            btnHowToPlay.Image = howtoplay_img;
            btnHowToPlay.Width = 250;
            btnHowToPlay.Height = 90;
            btnHowToPlay.BackColor = Color.Transparent;
            btnHowToPlay.SizeMode = PictureBoxSizeMode.StretchImage;


            Image credits_img = Properties.Resources.rsz_credits;
            btnCredits.Image =credits_img;
            btnCredits.Width = 250;
            btnCredits.Height = 90;
            btnCredits.BackColor = Color.Transparent;
            btnCredits.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        private void setTheme2() 
        { 
            //ovoj tema za Martina
        }
    }
}
