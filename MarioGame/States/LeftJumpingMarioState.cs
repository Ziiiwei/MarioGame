using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class LeftJumpingMarioState : IMarioState
    {
        private IMario mario;

        public LeftJumpingMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public void Crouch()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void Jump()
        {
            // Do nothing.
        }

        public void MoveLeft()
        {
            // Do nothing.
        }

        public void MoveRight()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
