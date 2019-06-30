using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class MarioFireCommand : ICommand
    {
        private IMario mario;

        public MarioFireCommand(IMario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.Fire();
        }
    }
}
