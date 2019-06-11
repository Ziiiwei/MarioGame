using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightJumpingMarioState : IMarioState
    {
        private IMario mario;

        public RightJumpingMarioState(IMario mario)
        {
            this.mario = mario;
        }

        public void Crouch()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void Jump()
        {
            // Nothing to do here...
        }

        public void MoveLeft()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveRight()
        {
            // Do nothing
        }
    }
}
