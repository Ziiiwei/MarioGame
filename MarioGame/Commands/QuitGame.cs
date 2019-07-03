using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class QuitGame : ICommand
    {

        public QuitGame(IGameObject obj)
        {
        }
        public void Execute()
        {
            MarioGame.Instance.Exit();
        }
    }
}
