using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class RedShroomLeftState : IShroomState
    {
        private RedShroom shroom;
        public RedShroomLeftState(RedShroom shroom)
        {
            this.shroom = shroom;
            shroom.GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }
        public void ChangeDirection()
        {
            shroom.State = new RedShroomRightState(shroom);
        }
    }
}
