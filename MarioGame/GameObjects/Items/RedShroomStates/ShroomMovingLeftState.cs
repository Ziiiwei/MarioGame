using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Items
{
    class ShroomMovingLeftState : IShroomState
    {
        private RedShroom shroom;
        public ShroomMovingLeftState(RedShroom shroom)
        {
            this.shroom = shroom;
            //shroom.GameObjectPhysics.Stop(Side.Left);
            shroom.GameObjectPhysics.JumpMaxSpeed(Side.Left);
        }
        public void ChangeDirection()
        {
            shroom.State = new ShroomMovingRightState(shroom);
        }
    }
}
