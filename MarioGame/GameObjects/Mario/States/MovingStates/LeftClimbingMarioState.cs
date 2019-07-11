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
            base.ClimbUp();
        }

        public override void ClimbDown()
        {
            base.ClimbDown();
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }

        public override void Land()
        {
            base.Land();
        }
    }
}
