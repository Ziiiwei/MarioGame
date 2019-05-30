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
            // Do nothing
        }

        public void Jump(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateRightJumpingMario(mario.PowerUpState);
            mario.SetState(new RightJumpingMarioState());
        }

        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateRightStandingMario(mario.PowerUpState);
            mario.SetState(new RightFacingStandingMarioState());
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
