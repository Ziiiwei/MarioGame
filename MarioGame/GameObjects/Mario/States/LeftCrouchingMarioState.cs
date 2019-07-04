using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gamespace.States
{
    class LeftCrouchingMarioState : MovingMarioState
    {

  
        public LeftCrouchingMarioState(IMario mario) : base(mario)
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
