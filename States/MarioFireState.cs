using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class MarioFireState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.PowerUpState = new MarioSuperState();
        }

        public void PowerUp(IMario mario)
        {
            // Do nothing
        }
    }
}
