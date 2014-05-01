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
    public partial class Form1 : Form
    {
        public Game TheGame { get; set; }
        public Timer TimerCreateLetter { get; set; }
        public Timer TimerMoveEnemies { get; set; }
        public Random Random { get; set; }
        public Form1()
        {
            InitializeComponent();
            newGame();
            /*InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
            List<string> fonts = new List<string>();
            foreach (FontFamily font in fontFamilies)
            {
                fonts.Add(font.Name);
                Console.WriteLine(font.Name);

            }*/

        }

        public void newGame()
        {
            //this.GetControls().Clear();
            this.KeyPreview = true;
            TheGame = new Game(this);
            if (TimerCreateLetter != null)
                TimerCreateLetter.Dispose();
            if(TimerMoveEnemies != null)
                TimerMoveEnemies.Dispose();
            TimerCreateLetter = new Timer();
            TimerCreateLetter.Tick += new EventHandler(TimerCreateLetter_Tick);
            TimerCreateLetter.Interval = TheGame.gameLevel.ENEMY_APPEAR;
            TimerCreateLetter.Start();
            TimerMoveEnemies = new Timer();
            TimerMoveEnemies.Tick += new EventHandler(TimerMoveEnemies_Tick);
            TimerMoveEnemies.Interval = TheGame.gameLevel.ENEMY_SPEED;
            TimerMoveEnemies.Start();
            Random = new Random();
            groupBox1.BackColor = Color.Transparent;
            lblScore.BackColor = Color.White;
            lblLevel.ForeColor = Color.White;
        }

        void TimerMoveEnemies_Tick(object sender, EventArgs e)
        {
            TheGame.MoveEnemies();
        }

        void TimerCreateLetter_Tick(object sender, EventArgs e)
        {
            TheGame.AddEnemy();
            lblLevel.Text = TheGame.gameLevel.LEVEL.ToString();
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
                    lblScore.Text = (int.Parse(lblScore.Text) + TheGame.gameLevel.POINTS_HIT).ToString();
                }
                else
                {
                    lblMiss.Text = (int.Parse(lblMiss.Text) + 1).ToString();
                    lblScore.Text = (int.Parse(lblScore.Text) - TheGame.gameLevel.POINTS_MISS).ToString();
                    if (int.Parse(lblScore.Text) < 0)
                        lblScore.Text = "0";
                }
                //e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TheGame.gameLevel.levelUp();
            
            foreach (Enemy enemy in TheGame.Enemies)
            {
                this.GetControls().Remove(enemy);
            }
            newGame();
        }
    }
}
