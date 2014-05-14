using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CharInvaders
{
    public class Enemy
    {
        public string Name { get; set; }
        public string Letter { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        protected Image Image = Properties.Resources.meteor;
        public int Width { get; set; }
        public int Height { get; set; }
        private Font Font;
        private static Brush brush = new SolidBrush(Color.Snow);

        public Enemy(Form f, int left, char letter)
        {
            Name = "Meteor";
            this.Letter = letter.ToString().ToUpper();
            this.Top = 30;
            this.Left = left;

            this.Width = Image.Width;
            this.Height = Image.Height;
            Font = new Font("Verdana", 15, FontStyle.Bold);
        }

        public void DrawEnemy(Graphics g)
        {
            g.DrawImage(Image, Left, Top);
        }

        public void DrawLetter(Graphics g)
        {
            if(Letter == "W")
                g.DrawString(Letter, Font, brush, Left + 4, Top + 23);
            else if(Letter == "I" || Letter == "J" || Letter == "L")
                g.DrawString(Letter, Font, brush, Left + 9, Top + 23);
            else    
                g.DrawString(Letter, Font, brush, Left + 7, Top + 23);
        }

        public void MoveEnemy(int value)
        {
            Top += value;
        }
    }
}
