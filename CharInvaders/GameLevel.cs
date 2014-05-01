using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class GameLevel
    {
        public int ENEMY_SPEED;
        public int LEVEL;
        public int ENEMY_APPEAR;
        public int POINTS_HIT;
        public int POINTS_MISS;
        public int MOVE_PIXELS;

        public GameLevel()
        {
            // Default values
            ENEMY_SPEED = 25;
            ENEMY_APPEAR = 1000;
            LEVEL = 1;
            POINTS_HIT = 100;
            POINTS_MISS = 300;
            MOVE_PIXELS = 2;
        }

        public void levelUp()
        {
            LEVEL++;
            ENEMY_APPEAR = (int)(ENEMY_APPEAR / 1.25);
            if(ENEMY_SPEED > 4)
                ENEMY_SPEED = (int)(ENEMY_SPEED * 0.75);
            POINTS_HIT = (int)(POINTS_HIT * 1.25);
            POINTS_MISS = POINTS_HIT * 3;
        }
    }
}
