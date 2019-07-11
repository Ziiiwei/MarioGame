using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class LeftWalkingMarioState : MovingMarioState
    {
        public LeftWalkingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.PowerUpState.Jump(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveLeft()
        {
            mario.GameObjectPhysics.Move(Side.Left);
        }

        public override void FrictionStop()
        {
            mario.GameObjectPhysics.FrictionStop(Side.Left);
            if (mario.GameObjectPhysics.Velocity.X == 0)
            {
                mario.State = new LeftStandingMarioState(mario);
                mario.UpdateArt();
            }
        }

        public override void Fire()
        {
            mario.Projectiles.Fire(Side.Left);
        }

        public override void ClimbUp()
        {
            mario.State = new LeftClimbingMarioState(mario);
            mario.GameObjectPhysics.Climb(Side.Up);
            mario.UpdateArt();
        }
    }
}
