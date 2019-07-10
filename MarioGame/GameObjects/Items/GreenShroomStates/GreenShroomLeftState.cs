using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class GreenShroomLeftState : IShroomState
    {
        private GreenShroom shroom;
        public GreenShroomLeftState(GreenShroom shroom)
        {
            this.shroom = shroom;
            shroom.GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }
        public void ChangeDirection()
        {
            shroom.State = new GreenShroomRightState(shroom);
        }
    }
}
