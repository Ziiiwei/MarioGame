using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MakeMarioSmall : ICommand
    {
        IMario mario;
        public MakeMarioSmall(IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.PowerUpState = new MarioSmallState();
            mario.Update();

        }
    }
}
