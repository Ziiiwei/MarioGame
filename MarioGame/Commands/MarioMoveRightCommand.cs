using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioMoveRightCommand : ICommand
    {
        private IMario mario;

        public MarioMoveRightCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.MoveRight();
        }
    }
}
