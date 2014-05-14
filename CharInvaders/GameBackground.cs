using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public static class GameBackground
    {
        static LinkedList<Image> backgrounds; 

        public static void Initialize() 
        {
            backgrounds = new LinkedList<Image>();
            backgrounds.AddLast(Properties.Resources.background1);
            backgrounds.AddLast(Properties.Resources.background2);
            backgrounds.AddLast(Properties.Resources.background3);
            backgrounds.AddLast(Properties.Resources.background4);
            backgrounds.AddLast(Properties.Resources.background5);
            backgrounds.AddLast(Properties.Resources.background6);
            backgrounds.AddLast(Properties.Resources.background7);
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
