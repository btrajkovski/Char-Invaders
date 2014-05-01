using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Game
    {
        public Dictionary<string, Enemy> Enemies { get; set; }
        private Form1 TheForm;

        public Game(Form1 form)
        {
            Enemies = new Dictionary<string, Enemy>();
            TheForm = form;
        }

        public bool AddEnemy(Enemy enemy)
        {
            if (!Enemies.ContainsKey(enemy.Text))
            {
                Enemies.Add(enemy.Text, enemy);
                TheForm.GetControls().Add(enemy);
                return true;
            }
            return false;
        }

        public void ShootEnemy(string enemy)
        {
            if (Enemies.ContainsKey(enemy))
            {
                Enemy e = null;
                Enemies.TryGetValue(enemy,out e);
                TheForm.GetControls().Remove(e);
                Enemies.Remove(enemy);
            }
            else
                MessageBox.Show("You missed!");
        }
    }
}
