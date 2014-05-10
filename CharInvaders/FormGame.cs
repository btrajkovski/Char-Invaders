using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WindowsFormsApplication1
{
    public partial class FormGame : Form
    {
        public Game TheGame { get; set; }
        public Timer TimerCreateLetter { get; set; }
        public Timer TimerMoveEnemies { get; set; }
        public FormMenu MenuForm;
        public int CurrentScore {set; get;}
        public bool IsPaused { set; get; }
        

        public FormGame(FormMenu menuForm)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MenuForm = menuForm;
            this.Location = menuForm.Location;
            newGame();
        }

        public void newGame()
        {
            this.BackgroundImage = Properties.Resources.background;
            this.KeyPreview = true;
            TheGame = new Game(this);
            InitializeTimers();
            CurrentScore = 0;

            Image i = Properties.Resources.rsz_exit;
            pbExit.Image = i;
            pbExit.Width = i.Width;
            pbExit.Height = i.Height;
            pbExit.BackColor = Color.Transparent;

            SetSoundImage();
            SetPauseImage();

            lblPause.Visible = IsPaused = false;
        }

        private void InitializeTimers()
        {
            if (TimerCreateLetter != null)
                TimerCreateLetter.Dispose();
            if (TimerMoveEnemies != null)
                TimerMoveEnemies.Dispose();

            TimerCreateLetter = new Timer();
            TimerCreateLetter.Tick += new EventHandler(TimerCreateLetter_Tick);
            TimerCreateLetter.Interval = TheGame.gameLevel.ENEMY_APPEAR;
            TimerCreateLetter.Start();
            TimerMoveEnemies = new Timer();
            TimerMoveEnemies.Tick += new EventHandler(TimerMoveEnemies_Tick);
            TimerMoveEnemies.Interval = TheGame.gameLevel.ENEMY_SPEED;
            TimerMoveEnemies.Start();
        }

        void TimerMoveEnemies_Tick(object sender, EventArgs e)
        {
            if (!IsPaused)
            {
                TheGame.MoveEnemies();
                Invalidate();
            }
        }

        void TimerCreateLetter_Tick(object sender, EventArgs e)
        {
            if (!IsPaused)
            {
                TheGame.AddEnemy();
                lblLevel.Text = TheGame.gameLevel.LEVEL.ToString();
            }
        }

        public ControlCollection GetControls()
        {
            return (ControlCollection)this.Controls;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                PauseTheGame();
                return;
            }

            if (!IsPaused && e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (TheGame.ShootEnemy(e.KeyCode.ToString().ToUpper()))
                {
                    CurrentScore += TheGame.gameLevel.POINTS_HIT;
                    lblScore.Text = CurrentScore.ToString();
                }
                else
                {
                    CurrentScore -= TheGame.gameLevel.POINTS_MISS;
                    lblScore.Text = CurrentScore.ToString();
                    if (int.Parse(lblScore.Text) < 0)
                    {
                        CurrentScore = 0;
                        lblScore.Text = "0";
                    }
                }
            }
        }


        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheGame.EndGame(false);
        }

        private void pbSound_Click(object sender, EventArgs e)
        {
            MenuForm.PlaySounds = TheGame.shouldPlay = !TheGame.shouldPlay;
            SetSoundImage();
        }

        private void SetSoundImage()
        {
            if (TheGame.shouldPlay)
            {
                Image ii = Properties.Resources.rsz_soundon;
                pbSound.Image = ii;
                pbSound.Width = ii.Width;
                pbSound.Height = ii.Height;
                pbSound.BackColor = Color.Transparent;
            }
            else
            {
                Image ii = Properties.Resources.rsz_soundoff;
                pbSound.Image = ii;
                pbSound.Width = ii.Width;
                pbSound.Height = ii.Height;
                pbSound.BackColor = Color.Transparent;
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            TheGame.EndGame(false);
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            PauseTheGame();
        }

        private void PauseTheGame()
        {
            lblPause.Visible = IsPaused = !IsPaused;
            SetPauseImage();
        }

        private void SetPauseImage()
        {
            if (IsPaused)
            {
                Image iii = Properties.Resources.rsz_pause3;
                pbPause.Image = iii;
                pbPause.Width = iii.Width;
                pbPause.Height = iii.Height;
                pbPause.BackColor = Color.Transparent;
                Invalidate();
            }
            else
            {
                Image iii = Properties.Resources.rsz_pause;
                pbPause.Image = iii;
                pbPause.Width = iii.Width;
                pbPause.Height = iii.Height;
                pbPause.BackColor = Color.Transparent;
            }
        }

        private void FormGame_Deactivate(object sender, EventArgs e)
        {
            lblPause.Visible = IsPaused = true;
        }

        private void FormGame_Activated(object sender, EventArgs e)
        {
            lblPause.Visible = IsPaused = false;
        }

        private void pbExit_MouseEnter(object sender, EventArgs e)
        {
            Image i = Properties.Resources.rsz_exit3;
            pbExit.Image = i;
            pbExit.Width = i.Width;
            pbExit.Height = i.Height;
            pbExit.BackColor = Color.Transparent;
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            Image i = Properties.Resources.rsz_exit;
            pbExit.Image = i;
            pbExit.Width = i.Width;
            pbExit.Height = i.Height;
            pbExit.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TheGame.Draw(e.Graphics);
        }
    }
}
