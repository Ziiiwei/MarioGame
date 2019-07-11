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
            mario.GameObjectPhysics.Climb(Side.Up);

        }

        public override void ClimbDown()
        {
            mario.GameObjectPhysics.Climb(Side.Down);
        }

        public override void Land()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }
    }
}
