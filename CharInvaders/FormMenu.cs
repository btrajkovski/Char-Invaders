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
        public bool PlaySounds { set; get; }
        public bool PlayThemeSong;
        public int Theme;

        public FormMenu()
        {
            InitializeComponent();
            SoundCollection = new SoundCollection();
            PlaySounds = true;
            PlayThemeSong = false;
            Theme = 0;
            this.DoubleBuffered = true;
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
            if (PlayThemeSong)
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
            int H = 32;
            int T = 100;
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
            btnHighScore.Top = T += H;
            btnHighScore.Width = W;
            btnHighScore.Height = H;
            btnHighScore.BackColor = Color.Transparent;
            btnHighScore.SizeMode = PictureBoxSizeMode.StretchImage;

            Image settings_img = Properties.Resources.settings_button;
            btnSettings.Image = settings_img;
            btnSettings.Left = L;
            btnSettings.Top = T += H;
            btnSettings.Width = W;
            btnSettings.Height = H;
            btnSettings.BackColor = Color.Transparent;
            btnSettings.SizeMode = PictureBoxSizeMode.StretchImage;

            Image howtoplay_img = Properties.Resources.howto_button;
            btnHowToPlay.Image = howtoplay_img;
            btnHowToPlay.Left = L;
            btnHowToPlay.Top = T += H;
            btnHowToPlay.Width = W;
            btnHowToPlay.Height = H;
            btnHowToPlay.BackColor = Color.Transparent;
            btnHowToPlay.SizeMode = PictureBoxSizeMode.StretchImage;


            Image credits_img = Properties.Resources.credits_button;
            btnCredits.Image = credits_img;
            btnCredits.Left = L;
            btnCredits.Top = T += H;
            btnCredits.Width = W;
            btnCredits.Height = H;
            btnCredits.BackColor = Color.Transparent;
            btnCredits.SizeMode = PictureBoxSizeMode.StretchImage;

            Image exit_img = Properties.Resources.exit_button;
            btnExit.Image = exit_img;
            btnExit.Left = L;
            btnExit.Top = T += H;
            btnExit.Width = W;
            btnExit.Height = H;
            btnExit.BackColor = Color.Transparent;
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play_button2;
        }

        private void btnHighScore_MouseEnter(object sender, EventArgs e)
        {
            btnHighScore.Image = Properties.Resources.score_button2;
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_button2;
        }

        private void btnHowToPlay_MouseEnter(object sender, EventArgs e)
        {
            btnHowToPlay.Image = Properties.Resources.howto_button2;
        }

        private void btnCredits_MouseEnter(object sender, EventArgs e)
        {
            btnCredits.Image = Properties.Resources.credits_button2;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play_button;
        }

        private void btnHighScore_MouseLeave(object sender, EventArgs e)
        {
            btnHighScore.Image = Properties.Resources.score_button;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_button;
        }

        private void btnHowToPlay_MouseLeave(object sender, EventArgs e)
        {
            btnHowToPlay.Image = Properties.Resources.howto_button;
        }

        private void btnCredits_MouseLeave(object sender, EventArgs e)
        {
            btnCredits.Image = Properties.Resources.credits_button;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.Image = Properties.Resources.exit_button2;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Image = Properties.Resources.exit_button;
        }
    }
}
