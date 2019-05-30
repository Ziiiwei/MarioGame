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
            mario.Sprite = SpriteFactory.Instance.CreateLeftStandingMario(mario.PowerUpState);
            mario.SetState(new LeftFacingStandingMarioState());
        }

        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftWalkingMario(mario.PowerUpState);
            mario.SetState(new LeftFacingWalkingMarioState());
        }

        public void MoveRight(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateRightWalkingMario(mario.PowerUpState);
            mario.SetState(new RightFacingWalkingMarioState());
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
