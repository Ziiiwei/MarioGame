using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class SmallStarMarioState : IMarioPowerUpState
    {
        public void PowerDown(IMario mario)
        {
            // do nothing
        }

        public void PowerUp(IMario mario)
        {
            mario.PowerUpState = new StarMarioState();
        }

        public void Fire(IMario mario)
        {

        }
    }
}
