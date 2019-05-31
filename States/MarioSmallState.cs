using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class MarioSmallState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.PowerUpState = new MarioDeadState();
        }

        public void PowerUp(IMario mario)
        {
            mario.PowerUpState = new MarioSuperState();
        }
    }
}
