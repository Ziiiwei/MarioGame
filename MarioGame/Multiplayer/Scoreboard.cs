using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Multiplayer
{
    class Scoreboard
    {
        public int Score { get; set; }
        public int Coins { get; set; }
        public int Lives { get; set; }

        public int Time { get; set; }

        private int StartingTime = 400;

        public Scoreboard(int lives)
        {
            Score = 0;
            Coins = 0;
            Lives = lives;
            Time = 400;
        }

        public void Update(GameTime gametime)
        {
            Time = StartingTime - (int)gametime.TotalGameTime.TotalSeconds;
        }
        
    }
}
