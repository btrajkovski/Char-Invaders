﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CharInvaders
{
    public class Theme
    {
        private Queue<Bitmap> BackgroundImages;
        public static Timer TimerBackgroundLoop;
        private Form form;

        public Theme()
        {
            InitializeBackground();
            TimerBackgroundLoop = new Timer();
            TimerBackgroundLoop.Tick += new EventHandler(t_Tick);

        }

        public void addTheme(Form f)
        {
            form = f;
            form.BackgroundImage = Properties.Resources.main_background1;
            TimerBackgroundLoop.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            Bitmap b = BackgroundImages.Dequeue();
            form.CreateGraphics().DrawImage(b, 0, 0);
            BackgroundImages.Enqueue(b);
        }

        private void InitializeBackground()
        {
            BackgroundImages = new Queue<Bitmap>();
            BackgroundImages.Enqueue(Properties.Resources.main_background1);
            BackgroundImages.Enqueue(Properties.Resources.main_background2);
            BackgroundImages.Enqueue(Properties.Resources.main_background3);
            BackgroundImages.Enqueue(Properties.Resources.main_background4);
        }
    }
}
