using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;

namespace CharInvaders
{
    public class Game
    {
        public List<Enemy> Enemies { get; set; }
        public List<Char> CharPool { get; set; }
        private FormGame TheForm;
        public Random Random { get; set; }
        public GameLevel gameLevel;
        public List<Cannon> Cannons { get; set; }
        private Graphics graphics;
        private PathGradientBrush brush;
        private Timer TimerSlowMotion;
        private int SecoundsLeft = 5;
        public bool isSlowMotionActive;
        private LinkedList<Explosion> Explosions;
        private Timer TimerExplosionLoop;

        public Game(FormGame form)
        {
            CharPool = new List<Char>();
            Enemies = new List<Enemy>();
            generatePool();
            TheForm = form;
            Random = new Random();
            gameLevel = new GameLevel();
            InitializeCannons();
            graphics = TheForm.CreateGraphics();
            TimerSlowMotion = new Timer();
            TimerSlowMotion.Interval = 1000;
            TimerSlowMotion.Tick += new EventHandler(TimerSlowMotion_Tick);
            isSlowMotionActive = false;
            Explosions = new LinkedList<Explosion>();
            Explosion.InitializeImages();
            TimerExplosionLoop = new Timer();
            TimerExplosionLoop.Interval = 50;
            TimerExplosionLoop.Tick += new EventHandler(TimerExplosionLoop_Tick);
            TimerExplosionLoop.Start();
        }

        void TimerExplosionLoop_Tick(object sender, EventArgs e)
        {
            if (!TheForm.IsPaused)
            {
                if (Explosions.Count > 0)
                {
                    foreach (Explosion explosion in Explosions)
                        explosion.NextImage();
                }
            }
        }

        void TimerSlowMotion_Tick(object sender, EventArgs e)
        {
            if (!TheForm.IsPaused)
            {
                if (SecoundsLeft > 1)
                {
                    SecoundsLeft--;
                    if (SecoundsLeft == 1)
                        SoundCollection.PlaySlowMotionFinish();
                }
                else
                {
                    TimerSlowMotion.Dispose();
                    TheForm.TimerCreateLetter.Interval = gameLevel.ENEMY_APPEAR;
                    SecoundsLeft = 5;

                    isSlowMotionActive = false;
                }
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
                if (gameLevel.LEVEL % 3 == 0)
                {
                    TheForm.BackgroundImage = GameBackground.NextImage();
                    TheForm.changeColorLabel();
                }
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

            if (!thereIsPower && !isSlowMotionActive && gameLevel.LEVEL > 1)
            {
                int rnd = Random.Next(0, 30);
                if (rnd == 7 && gameLevel.LEVEL > 3)
                    enemy = new PowerUp_SlowMotion(TheForm, findValidSpawn(), selected);
                else if (rnd > 26)
                    enemy = new PowerUp_Bonus(TheForm, findValidSpawn(), selected);
                else if (rnd == 13 && gameLevel.LEVEL > 4)
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
                    TheForm.TimerCreateLetter.Interval = gameLevel.ENEMY_APPEAR_SLOW_MOTION;
                    isSlowMotionActive = true;
                    TimerSlowMotion.Start();
                    SoundCollection.PlaySlowMotionStart();
                }
                if (res.Name == "Bonus")
                {
                    TheForm.CurrentScore += gameLevel.POINTS_HIT * 5;
                    TheForm.UpdateScore();
                }
                if (res.Name == "Destroyer")
                {
                    TheForm.CurrentScore += gameLevel.POINTS_HIT * Enemies.Count;
                    TheForm.UpdateScore();
                    foreach (Enemy e in Enemies)
                    {
                        if (e.Name != "Destroyer")
                            Explosions.AddLast(new Explosion(e.Left - 50, e.Top - 25));
                    }
                    Enemies = new List<Enemy>();
                }
                    
                Enemies.Remove(res);
                DrawStrike(res);
                SoundCollection.PlayLaserSound();
                return true;
            }
            else
                return false;

        }

        private void DrawStrike(Enemy res)
        {
            Cannon cannon = CannonToShot(res);
            Point[] points = { cannon.leftPoint, cannon.rightPoint, new Point(res.Left + res.Width / 2 + 3, res.Top + res.Height / 2 + 10),
                             new Point(res.Left + res.Width / 2 - 3, res.Top + res.Height / 2 + 10)};
            brush = new PathGradientBrush(points);
            brush.CenterPoint = new Point(cannon.Left + cannon.Width / 2, cannon.Top);
            brush.CenterColor = Color.Red;
            brush.SurroundColors = new[] { Color.Orange, Color.Orange};
            graphics.FillPolygon(brush, points, FillMode.Winding);
            Explosions.AddLast(new Explosion(res.Left - 50, res.Top - 25));
            brush.Dispose();
        }

        private void InitializeCannons()
        {
            int h = TheForm.Height;
            int w = TheForm.Width;
            Cannons = new List<Cannon>();
            //left cannon
            Cannons.Add(new Cannon(20, TheForm.Height, 35, h - 149, 87, h - 138));
            Cannons[0].SetImage(Properties.Resources.left_cannon);
            //middle cannon
            Cannons.Add(new Cannon((TheForm.Width - 30) / 2, TheForm.Height, w/2 - 8, h - 145, w/2+46, h - 145));
            Cannons[1].SetImage(Properties.Resources.middle_cannon);
            Cannons[1].Width = 67;
            Cannons[1].Height = 91;
            Cannons[1].Top = TheForm.Height - Cannons[1].Height - 54;
            //right cannon
            Cannons.Add(new Cannon(TheForm.Width - 90, TheForm.Height, w-84, h - 139, w-33, h - 149));
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
            Cannon cannon = ClosestCannon(Enemies[i]);
            Explosions.AddLast(new Explosion(cannon.Left - 35, cannon.Top));
            Cannons.Remove(cannon);
            Enemies.RemoveAt(i);
            SoundCollection.PlayCrushSound();
            ShakeForm();
        }

        public void EndGame(bool activateHighScore)
        {
            TheForm.IsPaused = true;
            Enemies = new List<Enemy>();
            gameLevel = new GameLevel();

            if (activateHighScore)
            {
                TheForm.MenuForm.frmScore.Show();
                TheForm.MenuForm.Tema.addTheme(TheForm.MenuForm.frmScore);
                TheForm.Hide();
                if (TheForm.MenuForm.frmScore.checkIfHighscore(TheForm.CurrentScore))
                {
                    FormAddScore frmAddScore = new FormAddScore();
                    DialogResult result = frmAddScore.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string x = frmAddScore.playerName;
                        if (x.Length == 0)
                            x = "NoName";
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

        private Cannon CannonToShot(Enemy enemy)
        {
            if (enemy.Left <= TheForm.Width / 3)
                return Cannons[Random.Next(Cannons.Count == 1 ? 0 : 1, Cannons.Count)];
            else if (enemy.Left > 2 / 3 * TheForm.Width)
                return Cannons[Random.Next(0, Cannons.Count - 1)];
            else
                return Cannons[Random.Next(0, Cannons.Count)];
        }

        private Cannon ClosestCannon(Enemy enemy)
        {
            int min = int.MaxValue;
            Cannon minCannon = null;
            foreach (Cannon cannon in Cannons)
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
                return enemy.Top + enemy.Height >= Cannons[0].Top + 5;
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
                   (left <= enemy.Left) && (left >= (enemy.Left - enemy.Width))) &&
                   (enemy.Top <= ( enemy.Height + 56));
        }

        public void Draw(Graphics g)
        {
            //drawing cannons
            foreach (Cannon c in Cannons)
            {
                c.DrawCannon(g);
            }

            //drawing explosions
            if (Explosions.Count > 0)
            {
                if (Explosion.Dispose > 0)
                {
                    for (int i = 0; i < Explosion.Dispose; i++)
                        Explosions.RemoveFirst();
                    Explosion.Dispose = 0;
                }
                foreach (Explosion e in Explosions)
                {
                    e.DrawImage(g);
                }
            }

            //drawing enemies
            foreach (Enemy e in Enemies)
            {
                e.DrawEnemy(g);
                if(!TheForm.IsPaused)
                    e.DrawLetter(g);
            }

            //drawing remaining time of powerup slow
            if (isSlowMotionActive)
            {
                g.DrawString(("Slow Time Bonus\n   " + SecoundsLeft + " seconds left").ToString(), new Font("Verdana", 13, FontStyle.Bold), new SolidBrush(TheForm.getColorLabel()), 100, 10);
            }
        }
    }
}
