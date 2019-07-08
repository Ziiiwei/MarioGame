using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    public class Scoreboard
    {
        private IMario mario;
        public Scoreboard(IMario mario)
        {
            this.mario = mario;
        }

        public void UpScore(int points)
        {
            mario.score += points;
        }
    }
}
