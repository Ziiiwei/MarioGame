using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightStandingMarioState : MovingMarioState
    {
        private IMario mario;

        public RightStandingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario; 
        }

        public override void Crouch()
        {
            mario.State = new RightCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }


        public override void MoveLeft()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.State = new RightWalkingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
