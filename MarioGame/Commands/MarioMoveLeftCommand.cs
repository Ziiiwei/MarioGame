using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioMoveLeftCommand : ICommand
    {
        private IMario mario;
        public MarioMoveLeftCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MoveLeft();
        }
    }
}
