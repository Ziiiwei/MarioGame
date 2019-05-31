using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    class RightJumpingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new RightFacingStandingMarioState();
        }

        public void Jump(IMario mario)
        {
            // Nothing to do here...
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing
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
