using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint2
{
    class LeftFacingCrouchingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Do nothing.
        }

        public void Jump(IMario mario)
        {
            mario.State = new LeftFacingStandingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            mario.State = new LeftFacingWalkingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightFacingWalkingMarioState();
            mario.UpdateArt();
        }
    }
}
