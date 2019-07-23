using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class RightClimbingMarioState : MovingMarioState
    {
        public  RightClimbingMarioState (IMario mario) : base(mario) { }

        public override void MoveLeft()
        {
            base.MoveLeft();
        }

        public override void Land()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void ClimbDown()
        {
            mario.GameObjectPhysics.Climb(Side.Down);
        }

        public override void ClimbUp()
        {
            mario.GameObjectPhysics.Climb(Side.Up);
        }
    }
}
