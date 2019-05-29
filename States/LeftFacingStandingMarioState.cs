using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;
using Sprint2.Interfaces;

namespace Sprint2
{
    class LeftFacingStandingMarioState : IMarioState
    {

        public void Crouch(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftCrouchingMario();
            mario.SetState(new LeftFacingCrouchingMarioState());
        }

        public void Jump(IMario mario)
        {
            // Do nothing.
        }

        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftWalkingMario();
            mario.SetState(new LeftFacingWalkingMarioState());
        }

        public void MoveRight(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateRightWalkingMario();
            mario.SetState(new RightFacingWalkingMarioState());
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
