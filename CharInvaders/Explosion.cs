using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Explosion
    {
        public int X { get; set; }
        public int Y { get; set; }
        private static List<Image> Images;
        public int Current { get; set; }
        public static int Dispose = 0;

        public Explosion(int x, int y)
        {
            X = x;
            Y = y;
            Current = 0;
        }

        public static void InitializeImages() 
        {
            Images = new List<Image>(19);
            Images.Add(Properties.Resources._1);
            Images.Add(Properties.Resources._2);
            Images.Add(Properties.Resources._3);
            Images.Add(Properties.Resources._4);
            Images.Add(Properties.Resources._5);
            Images.Add(Properties.Resources._6);
            Images.Add(Properties.Resources._7);
            Images.Add(Properties.Resources._8);
            Images.Add(Properties.Resources._9);
            Images.Add(Properties.Resources._10);
            Images.Add(Properties.Resources._11);
            Images.Add(Properties.Resources._12);
            Images.Add(Properties.Resources._13);
            Images.Add(Properties.Resources._14);
            Images.Add(Properties.Resources._15);
            Images.Add(Properties.Resources._16);
            Images.Add(Properties.Resources._17);
            Images.Add(Properties.Resources._18);
        }

        public void NextImage()
        {
            Current++;
            if (Current == 18)
                Dispose++;
        }

        public void DrawImage(Graphics g)
        {
            g.DrawImage(Images[Current], X, Y);
        }
    }
}
