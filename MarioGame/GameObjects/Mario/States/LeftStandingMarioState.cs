using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;

namespace Gamespace.States
{
    class LeftStandingMarioState : MovingMarioState
    {
        public LeftStandingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Crouch()
        {
            mario.State = new LeftCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.GameObjectPhysics.MoveMaxSpeed(Side.Up);
            mario.UpdateArt();
        }

        public override void MoveLeft()
        {
            mario.State = new LeftWalkingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Left);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
