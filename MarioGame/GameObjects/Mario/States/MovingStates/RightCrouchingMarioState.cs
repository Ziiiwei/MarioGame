using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightCrouchingMarioState : MovingMarioState
    {


        public RightCrouchingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }
        public override void Jump()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

    }
}
