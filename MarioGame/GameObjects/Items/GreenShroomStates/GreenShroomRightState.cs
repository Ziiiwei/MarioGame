using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class GreenShroomRightState : IShroomState
    {
        private GreenShroom shroom;
        public GreenShroomRightState(GreenShroom shroom)
        {
            this.shroom = shroom;
            shroom.GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }
        public void ChangeDirection()
        {
            shroom.State = new GreenShroomLeftState(shroom);
        }
    }
}
