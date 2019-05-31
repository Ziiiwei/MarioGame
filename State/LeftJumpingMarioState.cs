using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    class LeftJumpingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.State = new LeftCrouchingMarioState();
            mario.UpdateArt();
        }

        public void Jump(IMario mario)
        {
            // Do nothing.
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing.
        }

        public void MoveRight(IMario mario)
        {
            // Do nothing.
        }
    }
}
