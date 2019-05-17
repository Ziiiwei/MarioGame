using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class Move : ICommand
    {
        Game game;
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
