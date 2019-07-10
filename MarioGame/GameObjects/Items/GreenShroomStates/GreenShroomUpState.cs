using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class GreenShroomUpState : IShroomState
    {
        private GreenShroom shroom;
        public GreenShroomUpState(GreenShroom shroom)
        {
            this.shroom = shroom;
        }
        public void ChangeDirection()
        {
            shroom.State = new GreenShroomRightState(shroom);
        }
    }
}
