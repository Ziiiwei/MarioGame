using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class LeftWalkingMarioState : IMarioState
    {
        private IMario mario;

        public LeftWalkingMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public void Crouch()
        {
            // Nothing to do here...
        }

        public void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public void MoveLeft()
        {
            // Do nothing
        }

        public void MoveRight()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public void Update()
        {
            // Do nothing
        }
    }
}
