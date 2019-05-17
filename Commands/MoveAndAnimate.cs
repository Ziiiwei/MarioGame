using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class MoveAndAnimate : ICommand
    {
        Game game;
        public MoveAndAnimate(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
            game.MoveAndAnimate();
        }
    }
}
