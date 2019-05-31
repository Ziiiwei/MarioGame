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
            // Nothing to do here...
        }

        public void Jump(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftJumpingMarioState();
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing
        }

        public void MoveRight(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftFacingStandingMarioState();
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
