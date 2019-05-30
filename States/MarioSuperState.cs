using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MarioSuperState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.PowerUpState = new MarioSmallState();
        }

        public void PowerUp(IMario mario)
        {
            mario.PowerUpState = new MarioFireState();
        }
    }
}
