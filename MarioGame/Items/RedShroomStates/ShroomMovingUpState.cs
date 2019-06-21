using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class ShroomMovingUpState : IShroomState
    {
        private RedShroom shroom;
        public ShroomMovingUpState(RedShroom shroom)
        {
            this.shroom = shroom;
        }
        public void ChangeDirection()
        {
            shroom.State = new ShroomMovingRightState(shroom);
        }
    }
}
