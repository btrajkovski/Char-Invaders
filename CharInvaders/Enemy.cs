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
        public Enemy(Form f, int left, char letter)
        {
            int W = f.Size.Width;
            int H = f.Size.Height;

            this.BringToFront();
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Image image = Properties.Resources.testCometResized;
            this.Image = image;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.Width = image.Width;
            this.Height = image.Height;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Snow;
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Font = new Font("Verdana", 15, FontStyle.Bold); //new Font(this.Font.FontFamily, 15);
            Random rnd = new Random();
            this.Text = letter.ToString().ToUpper();
            this.Top = 56;
            this.Left = left;
            //this.BackColor = Color.FromArgb(rnd.Next(128, 256), rnd.Next(128, 256), rnd.Next(128, 256));
            
        }
    }
}
