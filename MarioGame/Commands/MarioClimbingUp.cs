using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioClimbingUpCommand : ICommand
    {
        private IMario mario;
        public MarioClimbingUpCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.ClimbUp();
        }
    }
   
}
