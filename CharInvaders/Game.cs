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
        public List<Enemy> Enemies { get; set; }
        public List<Char> CharPool { get; set; }
        private FormGame TheForm;
        public Random Random { get; set; }
        public GameLevel gameLevel;
        public List<Canon> Cannons { get; set; }
        private SoundCollection SoundCollection;
        public bool shouldPlay { set; get; }
        private Graphics graphics;
        private PathGradientBrush brush;
        private Timer TimerSlowMotion;
        private int SecoundsLeft = 5;
        public bool isSlowMotionActive;

        public Game(FormGame form)
        {
            CharPool = new List<Char>();
            Enemies = new List<Enemy>();
            generatePool();
            TheForm = form;
            Random = new Random();
            gameLevel = new GameLevel();
            InitializeCannons();
            SoundCollection = new SoundCollection();
            this.shouldPlay = TheForm.MenuForm.PlaySounds;
            graphics = TheForm.CreateGraphics();
            TimerSlowMotion = new Timer();
            TimerSlowMotion.Interval = 1000;
            TimerSlowMotion.Tick += new EventHandler(TimerSlowMotion_Tick);
            isSlowMotionActive = false;
        }

        void TimerSlowMotion_Tick(object sender, EventArgs e)
        {
            if (SecoundsLeft > 1)
            {
                SecoundsLeft--;
            }
            else
            {
                TimerSlowMotion.Dispose();
                //TheForm.TimerMoveEnemies.Interval = gameLevel.ENEMY_SPEED;
                TheForm.TimerCreateLetter.Interval = gameLevel.ENEMY_APPEAR;
                SecoundsLeft = 5;
                
                isSlowMotionActive = false;
            }
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
            int i = Random.Next(0, CharPool.Count);
            Char selected = CharPool[i];
            CharPool.RemoveAt(i);
            Enemy enemy = enemy = new Enemy(TheForm, findValidSpawn(), selected);
            bool thereIsPower = false;
            foreach (Enemy e in Enemies)
            {
                if (e.Name == "SlowMotion" || e.Name == "Bonus" || e.Name == "Destroyer")
                    thereIsPower = true;
            }

            if (!thereIsPower && !isSlowMotionActive && gameLevel.LEVEL > 2)
            {
                int rnd = Random.Next(0, 30);
                if (rnd == 7 && gameLevel.LEVEL > 4)
                    enemy = new PowerUp_SlowMotion(TheForm, findValidSpawn(), selected);
                else if (rnd == 13)
                    enemy = new PowerUP_Bonus(TheForm, findValidSpawn(), selected);
                else if (rnd == 23 && gameLevel.LEVEL > 6)
                    enemy = new PowerUp_Destroyer(TheForm, findValidSpawn(), selected);
            }
            Enemies.Add(enemy);
        }

        public bool ShootEnemy(string enemy)
        {
            Enemy res = null;
            foreach (Enemy enemyIterator in Enemies)
            {
                if (enemyIterator.Letter.ToString() == enemy)
                {
                    res = enemyIterator;
                    break;
                }
            }
            if (res != null)
            {
                if (res.Name == "SlowMotion")
                {
                    //TheForm.TimerMoveEnemies.Interval = gameLevel.ENEMY_SPEED_SLOW_MOTION;
                    TheForm.TimerCreateLetter.Interval = gameLevel.ENEMY_APPEAR_SLOW_MOTION;
                    isSlowMotionActive = true;
                    TimerSlowMotion.Start();
                   
                }
                if (res.Name == "Bonus")
                {
                    TheForm.CurrentScore += gameLevel.POINTS_HIT * 3;
                    TheForm.UpdateScore();
                }
                if (res.Name == "Destroyer")
                {
                    TheForm.CurrentScore += gameLevel.POINTS_HIT * Enemies.Count;
                    TheForm.UpdateScore();
                    Enemies = new List<Enemy>();
                }
                    
                Enemies.Remove(res);
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
            Point[] points = { cannon.leftPoint, cannon.rightPoint, new Point(res.Left + res.Width / 2 + 3, res.Top + res.Height / 2 + 10),
                             new Point(res.Left + res.Width / 2 - 3, res.Top + res.Height / 2 + 10)};
            brush = new PathGradientBrush(points);
            brush.CenterPoint = new Point(cannon.Left + cannon.Width / 2, cannon.Top);
            brush.CenterColor = Color.Red;
            brush.SurroundColors = new[] { Color.Orange, Color.Orange};
            graphics.FillPolygon(brush, points, FillMode.Winding);
            brush.Dispose();
        }

        private void InitializeCannons()
        {
            int h = TheForm.Height;
            int w = TheForm.Width;
            Cannons = new List<Canon>();
            //left cannon
            Cannons.Add(new Canon(20, TheForm.Height, 35, h - 149, 87, h - 138));
            Cannons[0].SetImage(Properties.Resources.left_cannon);
            //middle cannon
            Cannons.Add(new Canon((TheForm.Width - 30) / 2, TheForm.Height, w/2 - 8, h - 145, w/2+46, h - 145));
            Cannons[1].SetImage(Properties.Resources.middle_cannon);
            Cannons[1].Width = 67;
            Cannons[1].Height = 91;
            Cannons[1].Top = TheForm.Height - Cannons[1].Height - 54;
            //right cannon
            Cannons.Add(new Canon(TheForm.Width - 90, TheForm.Height, w-84, h - 139, w-33, h - 149));
            Cannons[2].SetImage(Properties.Resources.right_cannon);
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
                    Enemies[i].MoveEnemy(isSlowMotionActive ? gameLevel.MOVE_PIXELS_SLOW_MOTION : gameLevel.MOVE_PIXELS);
            }
        }

        private void RemoveCannon(int i)
        {
            Canon cannon = ClosestCannon(Enemies[i]);
            Cannons.Remove(cannon);
            Enemies.RemoveAt(i);
            if(shouldPlay)
                SoundCollection.PlayerCannonCrush.Play();
            ShakeForm();
        }

        public void EndGame(bool activateHighScore)
        {
            TheForm.IsPaused = true;
            Enemies = new List<Enemy>();
            gameLevel = new GameLevel();
            TheForm.MenuForm.playMusic();

            if (activateHighScore)
            {
                TheForm.MenuForm.frmScore.Show();
                TheForm.MenuForm.Tema.addTheme(TheForm.MenuForm.frmScore);
                TheForm.Hide();
                if (TheForm.MenuForm.frmScore.checkIfHighscore(TheForm.CurrentScore))
                {
                    FormAddScore fm = new FormAddScore();
                    DialogResult result = fm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string x = fm.playerName;
                        ScoreItem sc = new ScoreItem(x, TheForm.CurrentScore);
                        TheForm.MenuForm.frmScore.addScore(sc);
                    }
                }
                else MessageBox.Show("You did not make it in the first 5 :(");
            }
            else
            {
                TheForm.Hide();
                TheForm.MenuForm.Show();
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
                return Cannons[Random.Next(Cannons.Count == 1 ? 0 : 1, Cannons.Count)];
            else if (enemy.Left > 2 / 3 * TheForm.Width)
                return Cannons[Random.Next(0, Cannons.Count - 1)];
            else
                return Cannons[Random.Next(0, Cannons.Count)];
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

        private int findValidSpawn()
        {
            int left = 0;
            bool found = false;
            int count = 0;
            while (!found && count < 20)
            {
                left = Random.Next((int)(TheForm.Width * 0.05), (int)(TheForm.Width * 0.9));
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

        private static bool checkInvalidSpawn(int left, Enemy enemy)
        {
            return ((left >= enemy.Left) && (left <= (enemy.Left + enemy.Width)) ||
                   (left <= enemy.Left) && (left >= (enemy.Left - enemy.Width))) && (enemy.Top <= ( enemy.Height + 56));
        }

        public void Draw(Graphics g)
        {
            foreach (Enemy e in Enemies)
            {
                e.DrawEnemy(g);
                if(!TheForm.IsPaused)
                    e.DrawLetter(g);
            }
            foreach (Canon c in Cannons)
            {
                c.DrawCannon(g);
            }

            if (isSlowMotionActive)
            {
                g.DrawString(SecoundsLeft.ToString(), new Font("Verdana", 40, FontStyle.Bold), new SolidBrush(Color.Snow), 10, 50);
            }
        }
    }
}
