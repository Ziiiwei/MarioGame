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
            // nothing to do here...
        }

        public void MoveRight(IMario mario)
        {
            // nothing to do here...
        }
    }
}
