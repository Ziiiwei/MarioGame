using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class Animate : ICommand
    {
        private Game game;
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
