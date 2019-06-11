using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class LeftJumpingMarioState : MovingMarioState
    {
        private IMario mario;

        public LeftJumpingMarioState(IMario mario)
        {
            this.mario = mario;
        }
        public override void Crouch()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }
        public override void MoveRight()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
