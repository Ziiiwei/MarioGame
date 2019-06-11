using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class RightWalkingMarioState : MovingMarioState
    {
        private IMario mario;

        public RightWalkingMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public override void Jump()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }
        public override void MoveLeft()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
