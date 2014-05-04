using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;

namespace WindowsFormsApplication1
{
    public class Game
    {
        //public Dictionary<Char, Enemy> Enemies { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Char> CharPool { get; set; }
        private FormGame TheForm;
        public Random random { get; set; }
        public GameLevel gameLevel;
        public List<Canon> Cannons { get; set; }
        public Timer TimerStrike  { get; set; }
        private SoundCollection SoundCollection;
        public bool shouldPlay { set; get; }

        public Game(FormGame form)
        {
            CharPool = new List<Char>();
            Enemies = new List<Enemy>();
            generatePool();
            TheForm = form;
            random = new Random();
            gameLevel = new GameLevel();
            InitializeCannons();
            SoundCollection = new SoundCollection();
            TimerStrike = new Timer();
            TimerStrike.Interval = 100;
            TimerStrike.Tick += new EventHandler(TimerStrike_Tick);
            this.shouldPlay = TheForm.menuForm.shouldPlay;
        }

        private void InitializeCannons()
        {
            Cannons = new List<Canon>();
            Cannons.Add(new Canon(20, TheForm.Height));
            Cannons.Add(new Canon((TheForm.Width - 30)/2, TheForm.Height));
            Cannons.Add(new Canon(TheForm.Width - 50, TheForm.Height));
            foreach (Canon cannon in Cannons)
            {
                TheForm.GetControls().Add(cannon);
            }
        }

        void TimerStrike_Tick(object sender, EventArgs e)
        {
            TheForm.Invalidate();
            TimerStrike.Stop();
        }

        public void AddEnemy()
        {
            if (CharPool.Count == 0)
            {
                gameLevel.levelUp();
                TheForm.TimerCreateLetter.Interval = gameLevel.ENEMY_APPEAR;
                TheForm.TimerMoveEnemies.Interval = gameLevel.ENEMY_SPEED;
                generatePool();
            }
            int i = random.Next(0, CharPool.Count);
            Char selected = CharPool[i];
            CharPool.RemoveAt(i);
            Enemy enemy = new Enemy(TheForm, findValidSpawn(), selected);
            Enemies.Add(enemy);
            TheForm.GetControls().Add(enemy);
        }

        public bool ShootEnemy(string enemy)
        {
            Enemy res = null;
            foreach (Enemy enemyIterator in Enemies)
            {
                if (enemyIterator.Text.ToString() == enemy)
                {
                    res = enemyIterator;
                    break;
                }
            }
            if (res != null)
            {
                Enemies.Remove(res);
                TheForm.GetControls().Remove(res);
                DrawStrike(res);
                if(shouldPlay)
                SoundCollection.PlayerLaserSound.Play();
                return true;
            }
            else
                return false;

        }

        private void DrawStrike(Enemy res)
        {
            Canon cannon = CannonToShot(res);
            Graphics graphics = TheForm.CreateGraphics();
            Point[] points = { new Point(cannon.Left + cannon.Width/2 - 8, cannon.Top), new Point(cannon.Left + cannon.Width/2 + 8, cannon.Top), new Point(res.Left + res.Width / 2 + 5, res.Top + res.Height / 2),
                             new Point(res.Left + res.Width / 2 - 5, res.Top + res.Height / 2)};
            PathGradientBrush brush = new PathGradientBrush(points);
            brush.CenterPoint = new Point(cannon.Left + cannon.Width / 2, cannon.Top);
            brush.CenterColor = Color.DarkBlue;
            brush.SurroundColors = new[] { Color.White, Color.Violet};
            FillMode fillMode = FillMode.Winding;
            graphics.FillPolygon(brush, points, fillMode);
            TimerStrike.Start();
        }

        public void MoveEnemies()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (CanonIsHit(Enemies[i]))
                {
                    RemoveCannon(i);
                    if (Cannons.Count == 0)
                        EndGame(true);
                }
                else
                    Enemies[i].Top += gameLevel.MOVE_PIXELS;
            }
        }

        private void RemoveCannon(int i)
        {
            Canon cannon = ClosestCannon(Enemies[i]);
            TheForm.GetControls().Remove(cannon);
            Cannons.Remove(cannon);
            TheForm.GetControls().Remove(Enemies[i]);
            Enemies.RemoveAt(i);
            if(shouldPlay)
            SoundCollection.PlayerCannonCrush.Play();
            ShakeForm();
        }

        public void EndGame(bool activateHighScore)
        {
            TheForm.isPaused = true;
            foreach (Enemy enemy in Enemies)
            {
                TheForm.GetControls().Remove(enemy);
            }
            Enemies = new List<Enemy>();
            gameLevel = new GameLevel();
            TheForm.menuForm.playMusic();

            if (activateHighScore)
            {
                FormHighScore fhs = new FormHighScore(TheForm.menuForm);
                fhs.Show();
                TheForm.Hide();

                if (fhs.checkIfHighscore(TheForm.currentScore))
                {
                    FormAddScore fm = new FormAddScore();
                    DialogResult result = fm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string x = fm.playerName;
                        ScoreItem sc = new ScoreItem(x, TheForm.currentScore);
                        fhs.addScore(sc);
                        //MessageBox.Show(TheForm.menuForm.high.ToString());
                    }
                }
                else MessageBox.Show("You did not make it in the first 5 :(");
            }
            else
            {
                TheForm.Hide();
                TheForm.menuForm.Show();
            }
            
            
        }

        private void ShakeForm()
        {
            for (int i = 0; i < 5; i++)
            {
                int j = 0;
                TheForm.Left += 5;
                while (j < 9000000)
                    j++;
                TheForm.Top += 5;
                j = 0;
                while (j < 9000000)
                    j++;
                TheForm.Left -= 5;
                j = 0;
                while (j < 9000000)
                    j++;
                TheForm.Top -= 5;
            }
        }

        private Canon CannonToShot(Enemy enemy)
        {
            if (enemy.Left <= TheForm.Width / 3)
                return Cannons[random.Next(Cannons.Count == 1 ? 0 : 1, Cannons.Count)];
            else if (enemy.Left > 2 / 3 * TheForm.Width)
                return Cannons[random.Next(0, Cannons.Count - 1)];
            else
                return Cannons[random.Next(0, Cannons.Count)];
        }

        private Canon ClosestCannon(Enemy enemy)
        {
            int min = int.MaxValue;
            Canon minCannon = null;
            foreach (Canon cannon in Cannons)
            {
                if (Math.Abs(cannon.Left - enemy.Left) < min)
                {
                    min = Math.Abs(cannon.Left - enemy.Left);
                    minCannon = cannon;
                }
            }
            return minCannon;
        }

        private bool CanonIsHit(Enemy enemy)
        {
            if (Cannons.Count > 0)
                return enemy.Top + enemy.Height >= Cannons[0].Top;
            else
                return false;
        }

        private void generatePool()
        {
            for (Char i = 'a'; i <= 'z'; i++ )
            {
                CharPool.Add(i);
            }
        }

        /// <summary>
        /// Returns a valid (non overlapping) position for an enemy to spawn
        /// </summary>
        /// <returns>Value for the left coordinate</returns>
        private int findValidSpawn()
        {
            int left = 0;
            bool found = false;
            int count = 0;
            while (!found && count < 20)
            {
                left = random.Next((int)(TheForm.Width * 0.05), (int)(TheForm.Width * 0.9));
                found = true;
                foreach (Enemy enemy in Enemies)
                {
                    if (checkInvalidSpawn(left, enemy))
                    {
                        found = false;
                    }
                }
                count++;
            }
            return left;
        }

        /// <summary>
        /// Checks if the spawn position does not overlap with the other letter
        /// </summary>
        /// <param name="left">Left coordinate for the test enemy</param>
        /// <param name="enemy">Position of the already spawned enemy</param>
        /// <returns>True if invalid position, false otherwise</returns>
        private static bool checkInvalidSpawn(int left, Enemy enemy)
        {
            return ((left >= enemy.Left) && (left <= (enemy.Left + enemy.Width)) ||
                   (left <= enemy.Left) && (left >= (enemy.Left - enemy.Width))) && (enemy.Top <= ( enemy.Height + 56));
        }
    }
}
