using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    class Animate : ICommand
    {
        Game game;
        public Animate(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
            game.Animate();
        }
    }
}
