using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    class RightFacingStandingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Nothing to do here...
        }

        public void Jump(IMario mario)
        { 
            mario.State = new RightJumpingMarioState();
            mario.UpdateArt();
        }


        public void MoveLeft(IMario mario)
        {
            mario.State = new LeftFacingStandingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightFacingWalkingMarioState();
            mario.UpdateArt();
        }
    }
}
