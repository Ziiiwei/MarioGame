using Gamespace;
using Gamespace.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class PushMarioHorizontally : ICommand
    {
        IMario mario;
        public PushMarioHorizontally(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.CollideHorizontally();
        }
    }
}
