using Gamespace.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Characters
{
    class ClimbingCharacterState : LeftClimbingMarioState
    {
        public ClimbingCharacterState(IMario mario) : base(mario)
        {
        }

        public override void ClimbUp()
        {
            base.ClimbUp();
        }

        public override void ClimbDown()
        {
            base.ClimbDown();
        }

        public override void MoveLeft()
        {
            base.MoveLeft();
            mario.GameObjectPhysics.Move(Side.Left);
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            base.MoveRight();
        }

        public override void Land()
        {
            base.Land();
        }
    }
}
