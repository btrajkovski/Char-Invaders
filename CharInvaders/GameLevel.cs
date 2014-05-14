using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharInvaders
{
    public class GameLevel
    {
        public int ENEMY_SPEED;
        public int LEVEL;
        public int ENEMY_APPEAR;
        public int POINTS_HIT;
        public int POINTS_MISS;
        public int MOVE_PIXELS;
        public int ENEMY_SPEED_SLOW_MOTION;
        public int ENEMY_APPEAR_SLOW_MOTION;
        public int MOVE_PIXELS_SLOW_MOTION;

        public GameLevel()
        {
            // Default values
            ENEMY_SPEED = 25;
            ENEMY_APPEAR = 700;
            LEVEL = 1;
            POINTS_HIT = 100;
            POINTS_MISS = 300;
            MOVE_PIXELS = 2;
            ENEMY_SPEED_SLOW_MOTION = 40;
            ENEMY_APPEAR_SLOW_MOTION = 900;
            MOVE_PIXELS_SLOW_MOTION = 1;
        }

        public void levelUp()
        {
            LEVEL++;
            ENEMY_APPEAR = ENEMY_APPEAR < 10 ? (int)(ENEMY_APPEAR / 1.25) : ENEMY_APPEAR;
            if (MOVE_PIXELS < 4)
                MOVE_PIXELS += 1;
            POINTS_HIT = (int)(POINTS_HIT * 1.05);
            POINTS_MISS = POINTS_HIT * 3;
        }
    }
}
