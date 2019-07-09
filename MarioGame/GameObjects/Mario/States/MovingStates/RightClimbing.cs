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
            base.Jump();
        }

        public override void ClimbDown()
        {
            base.ClimbDown();
        }

        public override void ClimbUp()
        {
            base.ClimbUp();
        }
    }
}
