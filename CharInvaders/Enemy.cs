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
        private int Theme;

        public Enemy(Form f, int left, char letter, int Theme)
        {
            this.Theme = Theme;
            this.Letter = letter.ToString().ToUpper();
            this.Top = 40;
            this.Left = left;

            Image = Theme == 1 ? Properties.Resources.testCometResized : Properties.Resources.meteor2;
            this.Width = Image.Width;
            this.Height = Image.Height;
            Brush = Brushes.Snow;
            Font = new Font("Verdana", 15, FontStyle.Bold);
        }

        public void DrawEnemy(Graphics g)
        {
            if (Theme == 1)
            {
                g.DrawImage(Image, new Rectangle(Left, Top, 30, 50));
                g.DrawString(Letter, Font, Brush, Left + 5, Top + 25);
            }
            else
            {
                g.DrawImage(Image, Left, Top);
                g.DrawString(Letter, Font, Brush, Left + 7, Top + 23);
            }
        }

        public void MoveEnemy(int value)
        {
            Top += value;
        }
    }
}
