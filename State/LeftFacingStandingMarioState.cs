﻿using System;
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
            // Nothing to do here...
        }

        public void Jump(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftJumpingMarioState();
        }

        public void MoveLeft(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new LeftFacingWalkingMarioState();
        }

        public void MoveRight(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.GetSprite(mario.State, mario.PowerUpState);
            mario.State = new RightFacingStandingMarioState();
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
