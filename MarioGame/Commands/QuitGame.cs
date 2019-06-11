using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class QuitGame : ICommand
    {
        private MarioGame game;
        public QuitGame(MarioGame Game)
        {
            game = Game;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
