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
        public Random Random { get; set; }
        public FormMenu menuForm;
        public int currentScore {set; get;}
        public bool isPaused { set; get; }
        

        public FormGame(FormMenu menuForm)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.menuForm = menuForm;
            this.Location = menuForm.Location;
            newGame();
        }

        public void newGame()
        {
            this.KeyPreview = true;
            TheGame = new Game(this);
            InitializeTimers();
            Random = new Random();
            groupBox1.BackColor = Color.Transparent;
            currentScore = 0;
            Image i = Properties.Resources.rsz_exit;
            pbExit.Image = i;
            pbExit.Width = i.Width;
            pbExit.Height = i.Height;
            pbExit.BackColor = Color.Transparent;

            SetSoundImage();
            SetPauseImage();

            lblPause.Visible = isPaused = false;
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
            if (!isPaused)
            {
                TheGame.MoveEnemies();
                Invalidate();
            }
        }

        void TimerCreateLetter_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                TheGame.AddEnemy();
                lblLevel.Text = TheGame.gameLevel.LEVEL.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TheGame.AddEnemy();
            lblLevel.Text = TheGame.gameLevel.LEVEL.ToString();
        }

        public ControlCollection GetControls()
        {
            return (ControlCollection)this.Controls;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isPaused)
            {
                if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    if (TheGame.ShootEnemy(e.KeyCode.ToString().ToUpper()))
                    {
                        lblHit.Text = (int.Parse(lblHit.Text) + 1).ToString();
                        currentScore += TheGame.gameLevel.POINTS_HIT;
                        lblScore.Text = currentScore.ToString();
                    }
                    else
                    {
                        lblMiss.Text = (int.Parse(lblMiss.Text) + 1).ToString();
                        currentScore -= TheGame.gameLevel.POINTS_MISS;
                        lblScore.Text = currentScore.ToString();
                        if (int.Parse(lblScore.Text) < 0)
                        {
                            currentScore = 0;
                            lblScore.Text = "0";
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TheGame.gameLevel.levelUp();
        }

        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            TheGame.EndGame(false);
        }

        private void pbSound_Click(object sender, EventArgs e)
        {
            menuForm.shouldPlay = TheGame.shouldPlay = !TheGame.shouldPlay;
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
            lblPause.Visible = isPaused = !isPaused;
            SetPauseImage();
        }

        private void SetPauseImage()
        {
            if (isPaused)
            {
                Image iii = Properties.Resources.rsz_pause3;
                pbPause.Image = iii;
                pbPause.Width = iii.Width;
                pbPause.Height = iii.Height;
                pbPause.BackColor = Color.Transparent;
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
            lblPause.Visible = isPaused = true;
        }

        private void FormGame_Activated(object sender, EventArgs e)
        {
            lblPause.Visible = isPaused = false;
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
