using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class PushMarioVertically : ICommand
    {
        private IMario mario;
        public PushMarioVertically(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.CollideVertically();
        }
    }
}
