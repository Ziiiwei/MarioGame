using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Multiplayer;

namespace Gamespace.Commands
{
    class MarioAddLife: ICommand
    {

        private Scoreboard scoreboard;

        public MarioAddLife(Scoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public void Execute()
        {
            scoreboard.Lives += 1;
        }
    }
}
