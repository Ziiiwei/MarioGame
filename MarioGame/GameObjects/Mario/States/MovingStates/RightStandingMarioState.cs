using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class RightStandingMarioState : MovingMarioState
    {
        public RightStandingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Crouch()
        {
            mario.State = new RightCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.GameObjectPhysics.MoveMaxSpeed(Side.Up);
            mario.UpdateArt();

        }

        public override void MoveLeft()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();

        }

        public override void MoveRight()
        {
            mario.State = new RightWalkingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Right);
            mario.UpdateArt();

        }

        public override void Fire()
        {
            mario.Projectiles.Fire(Side.Right);
        }

        public override void ClimbUp()
        {
            mario.State = new RightClimbingMarioState(mario);
            mario.GameObjectPhysics.Climb(Side.Right);
            mario.UpdateArt();
        }

    }
}
