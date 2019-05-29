using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class RightFacingWalkingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.SetState(new RightFacingCrouchingMarioState());
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
            // Do nothing
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
