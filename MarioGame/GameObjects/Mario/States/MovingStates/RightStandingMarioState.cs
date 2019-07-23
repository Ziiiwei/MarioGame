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
            int previous_h = mario.Sprite.Height;
            mario.State = new RightCrouchingMarioState(mario);
            mario.UpdateArt();
            mario.GameObjectPhysics.IncrementMove(Side.Down, Math.Abs(mario.Sprite.Height - previous_h));
        }

        public override void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.GameObjectPhysics.Jump();
            mario.PowerUpState.Jump(mario);
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
            mario.GameObjectPhysics.Climb(Side.Up);
            mario.UpdateArt();
        }

    }
}
