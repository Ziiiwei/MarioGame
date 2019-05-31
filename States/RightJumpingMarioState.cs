using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightJumpingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.State = new RightStandingMarioState();
            mario.UpdateArt();
        }

        public void Jump(IMario mario)
        {
            // Nothing to do here...
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing
        }

        public void MoveRight(IMario mario)
        {
            // Do nothing
        }
    }
}
