using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class Reset : ICommand
    {
        private MarioGame game;
        public Reset(MarioGame thisGame)
        {
            game = thisGame;
        }
        public void Execute()
        {
            game.Reset();
        }
    }
}
