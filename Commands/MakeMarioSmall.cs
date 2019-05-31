using Gamespace;
using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
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
            mario.UpdateArt();

        }
    }
}
