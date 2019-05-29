using Sprint2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class LeftFacingWalkingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftCrouchingMario();
            mario.SetState(new LeftFacingCrouchingMarioState());
        }

        public void Jump(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftJumpingMario();
            mario.SetState(new LeftJumpingMarioState());
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing
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
