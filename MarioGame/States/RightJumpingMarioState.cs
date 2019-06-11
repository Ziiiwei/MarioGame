using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightJumpingMarioState : MovingMarioState
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
        public void MoveLeft()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
