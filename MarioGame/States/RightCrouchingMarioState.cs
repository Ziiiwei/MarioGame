using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightCrouchingMarioState : IMarioState
    {
        private IMario mario;

        public RightCrouchingMarioState(IMario mario)
        {
            this.mario = mario;
        }

        public void Crouch()
        {
            // Do nothing.
        }

        public void Jump()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveLeft()
        {
            // nothing to do here...
        }

        public void MoveRight()
        {
            // nothing to do here...
        }
    }
}
