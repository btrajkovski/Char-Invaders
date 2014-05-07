using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class BtnClear : PictureBox
    {
        int W = 101;
        int H = 32;

        public BtnClear()
        {
            Image back_img = Properties.Resources.clear_button;
            this.Image = back_img;
            this.Width = W;
            this.Height = H;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            base.MouseEnter += new EventHandler(BtnBack_MouseEnter);
            base.MouseLeave += new EventHandler(BtnBack_MouseLeave);
        }

        void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            this.Image = Properties.Resources.clear_button;
        }

        void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            this.Image = Properties.Resources.clear_button2;
        }
    }
}
