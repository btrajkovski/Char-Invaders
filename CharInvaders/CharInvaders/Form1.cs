using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public List<Enemy> Li { get; set; }
        public Game TheGame { get; set; }

        public Form1()
        {
            InitializeComponent();
            InitializeGravity();
            this.KeyPreview = true;
            Li = new List<Enemy>();
            TheGame = new Game(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            while (true)
            {
                if (TheGame.Enemies.Count > 25)
                    break;
                Enemy enemy = new Enemy(this);
                if (TheGame.AddEnemy(enemy))
                {
                    this.Controls.Add(enemy);
                    Li.Add(enemy);
                    label1.Text = (int.Parse(label1.Text) + 1).ToString();
                    break;
                }
            }
        }

        private void InitializeGravity()
        {
            
        }

        public ControlCollection GetControls()
        {
            return (ControlCollection)this.Controls;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> az = new Dictionary<string, bool>();
            for (int i = 97; i < 123; i++)
			{
			    az.Add(((char)i).ToString(), false);
			}

            foreach (Enemy enemu in Li)
            {
                az.Remove(enemu.Text);
                az.Add(enemu.Text, true);
            }

            foreach (bool b in az.Values)
            {
                if (b == false)
                {
                    MessageBox.Show("Ne e u redu!");
                    return;
                }
            }
            MessageBox.Show("U redu e!");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            groupBox1.Top = this.Size.Height - 107;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                TheGame.ShootEnemy(e.KeyCode.ToString().ToLower());
                e.Handled = true;
            }
        }
    }
}
