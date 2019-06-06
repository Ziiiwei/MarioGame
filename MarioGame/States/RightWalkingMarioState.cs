using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class RightWalkingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Do nothing
        }

        public void Jump(IMario mario)
        {
            mario.State = new RightJumpingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            mario.State = new RightStandingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            // Do nothing
        }

    }
}
