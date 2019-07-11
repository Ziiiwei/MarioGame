using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioClimingDownCommand : ICommand
    {
        private IMario mario;
        public MarioClimingDownCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.ClimbDown();
        }
    }
}
