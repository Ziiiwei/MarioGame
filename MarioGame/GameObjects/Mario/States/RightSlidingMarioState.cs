using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class RightSlidingMarioState : MovingMarioState
    {
        private IMario mario;

        public RightSlidingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        // this is what depends on Mario's velocity
        public override void MoveLeft()
        {
            mario.State = new RightWalkingMarioState(mario);
            mario.UpdateArt();
        }

        // mario should resume movement here
        public override void MoveRight()
        {

            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();

        }
    }
}
