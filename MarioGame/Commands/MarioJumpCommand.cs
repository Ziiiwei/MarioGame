using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioJumpCommand : ICommand
    {
        private IMario mario;   
        public MarioJumpCommand(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Jump();
        }
    }
}
