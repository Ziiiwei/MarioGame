using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class RightWalkingMarioState : IMarioState
    {
        private IMario mario;

        public RightWalkingMarioState(IMario mario)
        {
            this.mario = mario;
        }

        public void Crouch()
        {
            // Do nothing
        }

        public void Jump()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveLeft()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveRight()
        {
            // Do nothing
        }
    }
}
