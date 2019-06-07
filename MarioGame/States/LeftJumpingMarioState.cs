using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class LeftJumpingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            mario.State = new LeftStandingMarioState();
            mario.UpdateArt();
        }

        public void Jump(IMario mario)
        {
            // Do nothing.
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing.
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new RightJumpingMarioState();
            mario.UpdateArt();
        }
    }
}
