using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class CustomButton : PictureBox
    {
        int W = 101;
        int H = 32;
        Image PlainImage;
        Image FocusImage;

        public CustomButton()
        {
            this.Width = W;
            this.Height = H;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            base.MouseEnter += new EventHandler(BtnBack_MouseEnter);
            base.MouseLeave += new EventHandler(BtnBack_MouseLeave);
            PlainImage = Properties.Resources.back_button;
            FocusImage = Properties.Resources.back_button2;
        }

        public void SetImages(Image plain, Image focus)
        {
            PlainImage = plain;
            FocusImage = focus;
        }

        void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            this.Image = PlainImage;
        }

        void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            this.Image = FocusImage;
        }
    }

}
