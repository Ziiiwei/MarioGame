using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class MoveAndAnimate : ICommand
    {
        private Game game;
        public MoveAndAnimate(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
        }
    }
}
