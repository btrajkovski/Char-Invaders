using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CharInvaders
{
    public static class GameBackground
    {
        static LinkedList<Image> backgrounds;
        static LinkedList<Color> labelColor;


        public static void Initialize() 
        {
            backgrounds = new LinkedList<Image>();
            //backgrounds.AddLast(Properties.Resources.background1);
            backgrounds.AddLast(Properties.Resources.background2);
            backgrounds.AddLast(Properties.Resources.background3);
            backgrounds.AddLast(Properties.Resources.background4);
            backgrounds.AddLast(Properties.Resources.background5);
            backgrounds.AddLast(Properties.Resources.background6);
            backgrounds.AddLast(Properties.Resources.background7);

            labelColor = new LinkedList<Color>();
            //labelColor.AddLast(Color.DarkCyan);
            labelColor.AddLast(Color.RoyalBlue);
            labelColor.AddLast(Color.Blue);
            labelColor.AddLast(Color.DarkBlue);
            labelColor.AddLast(Color.LightBlue);
            labelColor.AddLast(Color.SkyBlue);
            labelColor.AddLast(Color.MediumAquamarine);


        }
        public static Color NextColor()
        {
            Color c = labelColor.First.Value;
            labelColor.RemoveFirst();
            labelColor.AddLast(c);
            return c;
        }

        public static Image NextImage()
        {
            Image res = backgrounds.First.Value;
            backgrounds.RemoveFirst();
            backgrounds.AddLast(res);
            return res;
        }
    }
}
