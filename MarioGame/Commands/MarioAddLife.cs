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

        private Player player;

        public MarioAddLife()
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Lives += 1;
        }
    }
}
