using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Canon
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public Image Image;
        public int Width { get; set; }
        public int Height { get; set; }
        public Point leftPoint, rightPoint;

        public Canon(int left, int formHeight, int pX, int pY, int p2X, int p2Y) 
        {
            this.Left = left;
            this.Width = 75;
            this.Height = 95;
            this.Top = formHeight - this.Height - 54;
            leftPoint = new Point(pX, pY);
            rightPoint = new Point(p2X, p2Y);
            //this.SizeMode = PictureBoxSizeMode.StretchImage;
            //this.BackColor = Color.Transparent;
        }

        public void SetImage(Image image)
        {
            this.Image = image;
        }

        public void DrawCannon(Graphics g)
        {
            g.DrawImage(Image, new Rectangle(Left, Top, Width, Height));
        }
    }
}
