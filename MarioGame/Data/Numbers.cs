using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.Data
{
    static class Numbers
    {
        public const int MARIO_JUMP_MAX_UPDATE = 10;// which is 0.1s
        public const int MARIO_JUMP_SPEED = 3; 
        public const int CAMERA_FACTOR = 2;
        public const int STOMP_TIMER_BOUND = 20;
        public static readonly int[] BUMP_OFFSETS = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
        public const int STAR_TIMER = 1000;
        public const int BOUNCE_BOUND = 5;
        public const int MAX_PROJECTILES = 3;
        public const int DELAY_BOUND = 12;
        public const int BLOCK_SPACING_SCALE = 32;
        public const int LIVES_STOCK = 3;
        public const int COUNTER_OFFSET = 50;
        public const int DISCREET_TIMER_START = 100;
        public const int STARTING_TIME = 400;
        public const Single VOLUME = 0.4f;
        public const int CENTER_X = 375;
        public const int CENTER_Y = 200;
        public const int WIDTH = 800;
        public const int HEIGHT = 480;
        public const int PLAYER_ONE_X = 200;
        public const int PLAYER_TWO_X = 1250;
        public const int STARTING_Y = 200;
        public const int PLAYERS_IN_GAME = 2;
        public const int CAMERA_START_X= 0;
        public const int FOREGROUND_DRAW_PRIORITY = 1;
        public const int LEVEL1_BLOCK_WIDTH = 206;
        public const int FIREBALL_REFILL_SPEED = 10;
        public const int BULLET1_BOUNCE_BOUND = 6;
    }
}
