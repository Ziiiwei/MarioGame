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
            mario.SetState(new LeftFacingCrouchingMarioState());
        }

        public void Jump(IMario mario)
        {
            // Do nothing
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
