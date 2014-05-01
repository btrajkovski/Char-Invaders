using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Enemy : Label
    {
        public Enemy(Form f)
        {
            int W = f.Size.Width;
            int H = f.Size.Height;

            this.Width = 10;
            this.Height = 15;

            Random rnd = new Random();
            this.Text = ((char)rnd.Next(97, 123)).ToString();
            this.Top = rnd.Next((int)(H * 0.05), (int)(H * 0.25));
            this.Left = rnd.Next((int)(W * 0.05), (int)(W * 0.9));
            this.BackColor = Color.FromArgb(rnd.Next(128, 256), rnd.Next(128, 256), rnd.Next(128, 256));
        }
    }
}
