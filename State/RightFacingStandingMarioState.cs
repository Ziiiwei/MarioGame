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
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new RightJumpingMarioState();
        }


        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftFacingStandingMarioState();
        }

        public void MoveRight(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new RightFacingWalkingMarioState();
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
