using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class LeftSlidingMarioState : MovingMarioState
    {
        private IMario mario;

        public LeftSlidingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario; 
        }

        public override void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }

        // mario should resume movement here
        public override void MoveLeft()
        {
            mario.State = new LeftWalkingMarioState(mario);
            mario.UpdateArt();
        }

        // this is what depends on Mario's velocity
        public override void MoveRight()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
            
        }
    }
}
