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
        private Queue<Bitmap> BackgroundImages;
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
            Theme = 0;
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
            btnPlay.Left = 182;
            btnPlay.Top = 13;
            btnPlay.Width = 250;
            btnPlay.Height = 90;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.SizeMode = PictureBoxSizeMode.StretchImage;

            Image highscore_img = Properties.Resources.rsz_highscore;
            btnHighScore.Image = highscore_img;
            btnHighScore.Left = 178;
            btnHighScore.Top = 102;
            btnHighScore.Width = 250;
            btnHighScore.Height = 90;
            btnHighScore.BackColor = Color.Transparent;
            btnHighScore.SizeMode = PictureBoxSizeMode.StretchImage;

            Image settings_img = Properties.Resources.rsz_settings;
            btnSettings.Image = settings_img;
            btnSettings.Left = 182;
            btnSettings.Top = 187;
            btnSettings.Width = 250;
            btnSettings.Height = 90;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.SizeMode = PictureBoxSizeMode.StretchImage;

            Image howtoplay_img = Properties.Resources.rsz_howtoplay;
            btnHowToPlay.Image = howtoplay_img;
            btnHowToPlay.Left = 178;
            btnHowToPlay.Top = 272;
            btnHowToPlay.Width = 250;
            btnHowToPlay.Height = 90;
            btnHowToPlay.BackColor = Color.Transparent;
            btnHowToPlay.SizeMode = PictureBoxSizeMode.StretchImage;


            Image credits_img = Properties.Resources.rsz_credits;
            btnCredits.Image = credits_img;
            btnCredits.Left = 178;
            btnCredits.Top = 361;
            btnCredits.Width = 250;
            btnCredits.Height = 90;
            btnCredits.BackColor = Color.Transparent;
            btnCredits.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        private void setTheme2() 
        { 
            //ovoj tema za Martina
            InitializeBackground();
            TimerBackgroundLoop.Start();
            this.BackgroundImage = Properties.Resources.main_background1;

            int W = 150;
            int H = 30;
            int T = 150;
            int L = this.Width / 2 - W / 2;

            Image play_img = Properties.Resources.play_button;
            btnPlay.Image = play_img;
            btnPlay.Left = L;
            btnPlay.Top = T;
            btnPlay.Width = W;
            btnPlay.Height = H;
            btnPlay.BackColor = Color.Transparent;
            btnPlay.SizeMode = PictureBoxSizeMode.StretchImage;

            Image highscore_img = Properties.Resources.score_button;
            btnHighScore.Image = highscore_img;
            btnHighScore.Left = L;
            btnHighScore.Top = T+30;
            btnHighScore.Width = W;
            btnHighScore.Height = H;
            btnHighScore.BackColor = Color.Transparent;
            btnHighScore.SizeMode = PictureBoxSizeMode.StretchImage;

            Image settings_img = Properties.Resources.settings_button;
            btnSettings.Image = settings_img;
            btnSettings.Left = L;
            btnSettings.Top = T+60;
            btnSettings.Width = W;
            btnSettings.Height = H;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.SizeMode = PictureBoxSizeMode.StretchImage;

            Image howtoplay_img = Properties.Resources.howto_button;
            btnHowToPlay.Image = howtoplay_img;
            btnHowToPlay.Left = L;
            btnHowToPlay.Top = T+90;
            btnHowToPlay.Width = W;
            btnHowToPlay.Height = H;
            btnHowToPlay.BackColor = Color.Transparent;
            btnHowToPlay.SizeMode = PictureBoxSizeMode.StretchImage;


            Image credits_img = Properties.Resources.credits_button;
            btnCredits.Image = credits_img;
            btnCredits.Left = L;
            btnCredits.Top = T+120;
            btnCredits.Width = W;
            btnCredits.Height = H;
            btnCredits.BackColor = Color.Transparent;
            btnCredits.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void InitializeBackground()
        {
            BackgroundImages = new Queue<Bitmap>();
            BackgroundImages.Enqueue(Properties.Resources.main_background1);
            BackgroundImages.Enqueue(Properties.Resources.main_background2);
            BackgroundImages.Enqueue(Properties.Resources.main_background3);
            BackgroundImages.Enqueue(Properties.Resources.main_background4);
        }

        private void TimerBackgroundLoop_Tick(object sender, EventArgs e)
        {
            if (Theme != 1)
            {
                Bitmap b = BackgroundImages.Dequeue();
                this.CreateGraphics().DrawImage(b, 0, 0);
                BackgroundImages.Enqueue(b);
            }
            else
                TimerBackgroundLoop.Stop();
        }
    }
}
