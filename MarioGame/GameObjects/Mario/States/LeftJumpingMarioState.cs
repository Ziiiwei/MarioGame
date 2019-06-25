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
 

        public LeftJumpingMarioState(IMario mario) : base(mario)
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
