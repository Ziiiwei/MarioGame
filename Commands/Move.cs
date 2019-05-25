using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class Move :ICommand
    {
        private Game game;
        public Move(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
            game.Move();
        }
    }
}
