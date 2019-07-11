using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class RightClimbingMarioState : MovingMarioState
    {
        public RightClimbingMarioState(IMario mario) : base(mario)
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

        public override void MoveLeft()
        {
            mario.GameObjectPhysics.Move(Side.Left);
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Land()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
