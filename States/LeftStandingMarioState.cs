using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;

namespace Gamespace.States
{
    class LeftStandingMarioState : IMarioState
    {

        public void Crouch(IMario mario)
        {
            mario.State = new LeftCrouchingMarioState();
            mario.UpdateArt();
        }

        public void Jump(IMario mario)
        {
            mario.State = new LeftJumpingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            mario.State = new LeftWalkingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightStandingMarioState();
            mario.UpdateArt();
        }
    }
}
