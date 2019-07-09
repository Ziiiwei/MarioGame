using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    class LeftClimbingMarioState: MovingMarioState
    {
        public LeftClimbingMarioState(IMario mario) : base(mario)
        {
        }

        public override void ClimbUp()
        {
            base.ClimbUp();
        }

        public override void ClimbDown()
        {
            base.ClimbDown();
        }

        public override void Land()
        {
            base.Land();
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }
    }
}
