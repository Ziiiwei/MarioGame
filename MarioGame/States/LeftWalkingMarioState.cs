using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class LeftWalkingMarioState : IMarioState
    {
        public void Crouch(IMario mario)
        {
            // Nothing to do here...
        }

        public void Jump(IMario mario)
        {
            mario.State = new LeftJumpingMarioState();
            mario.UpdateArt();
        }

        public void MoveLeft(IMario mario)
        {
            // Do nothing
        }

        public void MoveRight(IMario mario)
        {
            mario.State = new LeftStandingMarioState();
            mario.UpdateArt();
        }

        public void Update(IMario mario)
        {
            throw new NotImplementedException();
        }

    }
}
