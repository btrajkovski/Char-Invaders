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
            this.Letter = letter.ToString().ToUpper();
            this.Top = 40;
            this.Left = left;

            Image = Properties.Resources.meteor2;
            this.Width = Image.Width;
            this.Height = Image.Height;
            Brush = Brushes.Snow;
            Font = new Font("Verdana", 15, FontStyle.Bold);
        }

        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(Image, Left, Top);
        }

        public void DrawLetter(Graphics g)
        {
            g.DrawString(Letter, Font, Brush, Left + 7, Top + 23);
        }

        public void MoveEnemy(int value)
        {
            Top += value;
        }
    }
}
