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
        public FormHighScore fhs;
        public FormSettings fs;
        public FormHowTo fh;
        public FormCredits fc;
        public Theme tema;


        public FormMenu()
        {
            InitializeComponent();
            SoundCollection = new SoundCollection();
            PlaySounds = true;
            PlayThemeSong = true;
            this.DoubleBuffered = true;
            fhs = new FormHighScore(this);
            fs = new FormSettings(this);
            fh = new FormHowTo(this);
            fc = new FormCredits(this);
            tema = new Theme();
            tema.addTheme(this);
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
            tema.addTheme(fhs);
            this.Hide();
            fhs.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            tema.addTheme(fs);
            this.Hide();
            fs.Show();

        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            tema.addTheme(fh);
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
            tema.addTheme(fc);
            this.Hide();
            fc.Show();
        }
        
        private void setTheme() 
        { 
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
                Bitmap b = BackgroundImages.Dequeue();
                this.CreateGraphics().DrawImage(b, 0, 0);
                BackgroundImages.Enqueue(b);
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

        private void FormMenu_Activated(object sender, EventArgs e)
        {
            tema.addTheme(this);

        }
    }
}