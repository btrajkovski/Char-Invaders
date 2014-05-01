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
        private Form1 TheForm;
        public Random random { get; set; }
        public GameLevel gameLevel;
        public List<Canon> Canons { get; set; }
        public Timer TimerStrike  { get; set; }
        private SoundPlayer PlayerLaserSound;
        private SoundPlayer PlayerCannonCrush;


        public Game(Form1 form)
        {
            CharPool = new List<Char>();
            Enemies = new List<Enemy>();
            generatePool();
            TheForm = form;
            random = new Random();
            gameLevel = new GameLevel();
            PlayerLaserSound = new SoundPlayer(Properties.Resources.mywavfile);
            PlayerCannonCrush = new SoundPlayer(Properties.Resources.explosion_iceman);
            InitializeCannons();
            
            TimerStrike = new Timer();
            TimerStrike.Interval = 100;
            TimerStrike.Tick += new EventHandler(TimerStrike_Tick);
        }

        private void InitializeCannons()
        {
            Canons = new List<Canon>();
            Canon[] canon = { new Canon(20, TheForm.Height), new Canon((TheForm.Width - 30)/2, TheForm.Height), new Canon(TheForm.Width - 50, TheForm.Height) };
            Canons.Add(canon[0]);
            Canons.Add(canon[1]);
            Canons.Add(canon[2]);
            TheForm.GetControls().Add(canon[0]);
            TheForm.GetControls().Add(canon[1]);
            TheForm.GetControls().Add(canon[2]);
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
            //Enemies.Add(selected, enemy);
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
                PlayerLaserSound.Play();
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
            //graphics.DrawPolygon(new Pen(Color.Red), points);
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
            bool isHit = false;
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (CanonIsHit(Enemies[i]))
                {
                    Canon cannon = ClosestCannon(Enemies[i]);
                    TheForm.GetControls().Remove(Enemies[i]);
                    Enemies.RemoveAt(i);
                    isHit = true;
                    TheForm.GetControls().Remove(cannon);
                    Canons.Remove(cannon);
                    if (Canons.Count == 0)
                    {
                        MessageBox.Show("Game Over !!!");
                        foreach (Enemy enemy in Enemies)
                        {
                            TheForm.GetControls().Remove(enemy);
                        }
                        TheForm.newGame();
                    }
                }
                else
                    Enemies[i].Top += gameLevel.MOVE_PIXELS;
            }

            if (isHit)
            {
                PlayerCannonCrush.Play();
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
                
            
        }

        private Canon CannonToShot(Enemy enemy)
        {
            if (enemy.Left <= TheForm.Width / 3)
                return Canons[random.Next(Canons.Count == 1 ? 0 : 1, Canons.Count)];
            else if (enemy.Left > 2 / 3 * TheForm.Width)
                return Canons[random.Next(0, Canons.Count - 1)];
            else
                return Canons[random.Next(0, Canons.Count)];
        }

        private Canon ClosestCannon(Enemy enemy)
        {
            int min = int.MaxValue;
            Canon minCannon = null;
            foreach (Canon cannon in Canons)
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
            if (Canons.Count > 0)
                return enemy.Top + enemy.Height >= Canons[0].Top;
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
                    if (checkValidSpawn(left, enemy))
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
        /// <returns>True if valid position, false otherwise</returns>
        private static bool checkValidSpawn(int left, Enemy enemy)
        {
            return ((left >= enemy.Left) && (left <= (enemy.Left + enemy.Width)) ||
                   (left <= enemy.Left) && (left >= (enemy.Left - enemy.Width))) && (enemy.Top <= enemy.Height);
        }
    }
}
