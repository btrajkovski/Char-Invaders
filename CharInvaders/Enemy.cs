using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Enemy
    {
        public string Letter { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public Image Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private Font Font;
        private Brush Brush;

        public Enemy(Form f, int left, char letter)
        {
            int W = f.Size.Width;
            int H = f.Size.Height;
            this.Letter = letter.ToString().ToUpper();
            this.Top = 56;
            this.Left = left;

            Image = Properties.Resources.testCometResized;
            this.Width = Image.Width;
            this.Height = Image.Height;
            Brush = Brushes.Snow;
            Font = new Font("Verdana", 15, FontStyle.Bold);
        }

        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(Image, new Rectangle(Left, Top, 30, 50));
            g.DrawString(Letter, Font, Brush, Left + 5, Top + 25);
        }

        public void MoveEnemy(int value)
        {
            Top += value;
        }
    }
}
