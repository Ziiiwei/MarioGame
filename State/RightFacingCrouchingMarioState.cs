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
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftFacingStandingMarioState();
        }

        public void MoveLeft(IMario mario)
        {
            // nothing to do here...
        }

        public void MoveRight(IMario mario)
        {
            // nothing to do here...
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
