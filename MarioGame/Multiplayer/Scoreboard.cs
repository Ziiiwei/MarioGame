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

        public Scoreboard(int lives)
        {
            Score = 0;
            Coins = 0;
            Lives = lives;
        }

        public void Update()
        {
            // put timer stuff here
        }
        
    }
}
