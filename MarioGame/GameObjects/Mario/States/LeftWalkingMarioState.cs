using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class LeftWalkingMarioState : MovingMarioState
    {
        private IMario mario;

        public LeftWalkingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
