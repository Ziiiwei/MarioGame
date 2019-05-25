using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class QuitGame : ICommand
    {
        private Game game;
        public QuitGame(Game thisGame)
        {
            game = thisGame;
        }
        public void Execute()
        {
            game.Exit();
        }
    }
}
