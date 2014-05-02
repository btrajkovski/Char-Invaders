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
            this.menuForm = menuForm;
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

            Image ii = Properties.Resources.rsz_note;
            pbSound.Image = ii;
            pbSound.Width = ii.Width;
            pbSound.Height = ii.Height;
            pbSound.BackColor = Color.Transparent;

            Image iii = Properties.Resources.rsz_pause;
            pbPause.Image = iii;
            pbPause.Width = iii.Width;
            pbPause.Height = iii.Height;
            pbPause.BackColor = Color.Transparent;

            isPaused = false;
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
            if(!isPaused)
                TheGame.MoveEnemies();
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
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (TheGame.ShootEnemy(e.KeyCode.ToString().ToUpper()))
                {
                    lblHit.Text = (int.Parse(lblHit.Text) + 1).ToString();
                    currentScore += TheGame.gameLevel.POINTS_HIT;
                    //lblScore.Text = (int.Parse(lblScore.Text) + TheGame.gameLevel.POINTS_HIT).ToString();
                    lblScore.Text = currentScore.ToString();
                }
                else
                {
                    lblMiss.Text = (int.Parse(lblMiss.Text) + 1).ToString();
                    currentScore -= TheGame.gameLevel.POINTS_MISS;
                   // lblScore.Text = (int.Parse(lblScore.Text) - TheGame.gameLevel.POINTS_MISS).ToString();
                    lblScore.Text = currentScore.ToString();
                    if (int.Parse(lblScore.Text) < 0)
                    {
                        currentScore = 0;
                        lblScore.Text = "0";
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
            TheGame.EndGame();
        }





        private void pbSound_Click(object sender, EventArgs e)
        {
            TheGame.shouldPlay = !TheGame.shouldPlay;
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            TheGame.EndGame();
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
        }

        private void FormGame_Deactivate(object sender, EventArgs e)
        {
            isPaused = true;
        }

        private void FormGame_Activated(object sender, EventArgs e)
        {
            isPaused = false;
        }

    }
}
