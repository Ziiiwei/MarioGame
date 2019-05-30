using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MakeMarioBig : ICommand
    {
        IMario mario;
        public MakeMarioBig(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.PowerUpState = new MarioSuperState();
        }
    }
}
