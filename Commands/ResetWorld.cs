using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class ResetWorld : ICommand
    {
        MarioGame game;
        public ResetWorld(MarioGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.ResetLevel();
        }
    }
}
