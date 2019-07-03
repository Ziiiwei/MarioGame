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
            mario.UpdateArt();
        }

        public void PowerUp(IMario mario)
        {
            // Do nothing
        }

        public void Fire(IMario mario)
        {
            mario.Projectiles.Fire();
        }
    }
}
