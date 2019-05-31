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
            mario.State = new LeftJumpingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            mario.State = new LeftFacingWalkingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightFacingStandingMarioState();
            mario.UpdateArt();
        }
    }
}
