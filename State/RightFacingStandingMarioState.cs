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
            mario.Sprite = SpriteFactory.Instance.CreateRightJumpingMario(mario.PowerUpState);
            mario.SetState(new RightJumpingMarioState());
        }


        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftStandingMario(mario.PowerUpState);
            mario.SetState(new LeftFacingStandingMarioState());
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
