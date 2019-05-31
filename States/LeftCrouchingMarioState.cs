using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.States
{
    class LeftCrouchingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Do nothing.
        }

        public void Jump(IMario mario)
        {
            mario.State = new LeftStandingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            //Nothing to do here...
        }

        public void MoveRight(IMario mario)
        {
            //nothing to do here...
        }
    }
}
