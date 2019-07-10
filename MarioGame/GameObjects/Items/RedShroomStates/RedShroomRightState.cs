using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class RedShroomRightState : IShroomState
    {
        private RedShroom shroom;
        public RedShroomRightState(RedShroom shroom)
        {
            this.shroom = shroom;
            shroom.GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }
        public void ChangeDirection()
        {
            shroom.State = new RedShroomLeftState(shroom);
        }
    }
}
