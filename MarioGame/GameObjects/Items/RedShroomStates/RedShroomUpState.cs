using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class RedShroomUpState : IShroomState
    {
        private RedShroom shroom;
        public RedShroomUpState(RedShroom shroom)
        {
            this.shroom = shroom;
        }
        public void ChangeDirection()
        {
            shroom.State = new RedShroomRightState(shroom);
        }
    }
}
