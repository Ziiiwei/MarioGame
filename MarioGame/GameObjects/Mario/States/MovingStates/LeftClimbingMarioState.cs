using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.States;

namespace Gamespace.States
{
    class LeftClimbingMarioState : MovingMarioState
    {
        public LeftClimbingMarioState(IMario mario) :base(mario)
        {
            this.mario = mario;
        }

        public override void ClimbUp()
        {
            mario.GameObjectPhysics.Climb(Side.Up);
        }

        public override void ClimbDown()
        {
            mario.GameObjectPhysics.Climb(Side.Down);
        }

        public override void MoveRight()
        {
            mario.GameObjectPhysics.Move(Side.Right);
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Land()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
