using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Commands
{
    class Display : ICommand
    {
        private Game game;

        public Display(Game myGame)
        {
            game = myGame;
        }

        public void Execute()
        {
        }
    }
}
