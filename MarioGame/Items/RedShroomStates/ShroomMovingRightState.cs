using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class ShroomMovingRightState : IShroomState
    {
        private RedShroom shroom;
        public ShroomMovingRightState(RedShroom shroom)
        {
            this.shroom = shroom;
        }
        public void ChangeDirection()
        {
            shroom.State = new ShroomMovingLeftState(shroom);
        }
    }
}
