using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.States
{
    class LeftCrouchingMarioState : IMarioState
    {
        private IMario mario;

        public LeftCrouchingMarioState(IMario mario)
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
            //Nothing to do here...
        }

        public void MoveRight()
        {
            //nothing to do here...
        }
    }
}
