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
            mario.Sprite = SpriteFactory.Instance.CreateRightCrouchingMario();
            mario.SetState(new RightFacingCrouchingMarioState());
        }

        public void Jump(IMario mario)
        { 
            mario.Sprite = SpriteFactory.Instance.CreateRightJumpingMario();
            mario.SetState(new RightJumpingMarioState());
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
