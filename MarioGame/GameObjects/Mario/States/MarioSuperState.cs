using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class MarioSuperState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            mario.PowerUpState = new MarioSmallState();
            mario.UpdateArt();
        }

        public void PowerUp(IMario mario)
        {
            mario.PowerUpState = new MarioFireState();
            mario.UpdateArt();
        }
    }
}
