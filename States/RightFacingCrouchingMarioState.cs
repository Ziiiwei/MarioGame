using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    class RightFacingCrouchingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Do nothing.
        }

        public void Jump(IMario mario)
        {
            mario.SetState(new LeftFacingStandingMarioState());
        }

        public void MoveLeft(IMario mario)
        {
            mario.SetState(new LeftFacingWalkingMarioState());
        }

        public void MoveRight(IMario mario)
        {
            mario.SetState(new RightFacingWalkingMarioState());
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
