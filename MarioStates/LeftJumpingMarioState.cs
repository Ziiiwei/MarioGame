﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    class LeftJumpingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.Sprite = SpriteFactory.Instance.CreateLeftStandingMario();
            mario.SetState(new LeftFacingCrouchingMarioState());
        }

        public void Jump(IMario mario)
        {
            // Do nothing.
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing.
        }

        public void MoveRight(IMario mario)
        {
            // Do nothing.
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }
    }
}
