using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioClimbingDownCommand : ICommand
    {
        private IMario mario;
        public MarioClimbingDownCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.ClimbDown();
        }
    }
}
