using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.States
{
    class LeftCrouchingMarioState : MovingMarioState
    {
        private IMario mario;

        public LeftCrouchingMarioState(IMario mario)
        {
            this.mario = mario;
        }

        public override void Jump()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
