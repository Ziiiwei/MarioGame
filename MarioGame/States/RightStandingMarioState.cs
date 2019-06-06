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
        public void Crouch(IMario mario)
        {
            mario.State = new RightCrouchingMarioState();
            mario.UpdateArt();
        }

        public void Jump(IMario mario)
        { 
            mario.State = new RightJumpingMarioState();
            mario.UpdateArt();
        }


        public void MoveLeft(IMario mario)
        {
            mario.State = new LeftStandingMarioState();
            mario.UpdateArt();
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightWalkingMarioState();
            mario.UpdateArt();
        }

    }
}
