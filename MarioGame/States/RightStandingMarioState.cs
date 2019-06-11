using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightStandingMarioState : IMarioState
    {
        private IMario mario;

        public RightStandingMarioState(IMario mario)
        {
            this.mario = mario; 
        }

        public void Crouch()
        {
            mario.State = new RightCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }


        public void MoveLeft()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveRight()
        {
            mario.State = new RightWalkingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
