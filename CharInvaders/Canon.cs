using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Canon : PictureBox
    {
        public Canon(int left, int formHeight) 
        {
            this.Height = 100;
            this.Width = 40;
            this.Left = left;
            
            this.Top = formHeight - this.Height - 50;
            this.Image = Properties.Resources.tower2;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }
    }
}
