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
            this.Left = left;
            this.Width = 75;
            this.Height = 95;
            this.Top = formHeight - this.Height - 54;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = Color.Transparent;
        }

        public void SetImage(Image image)
        {
            this.Image = image;
        }
    }
}
