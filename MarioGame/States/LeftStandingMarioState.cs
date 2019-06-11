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
        private IMario mario;

        public LeftStandingMarioState(IMario mario)
        {
            this.mario = mario;
        }

        public void Crouch()
        {
            mario.State = new LeftCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveLeft()
        {
            mario.State = new LeftWalkingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveRight()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
