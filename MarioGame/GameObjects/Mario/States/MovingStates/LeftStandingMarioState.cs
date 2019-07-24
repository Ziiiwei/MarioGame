using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;
using Gamespace.Projectiles;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class LeftStandingMarioState : MovingMarioState
    {
        public LeftStandingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Crouch()
        {
            int previous_h = mario.Sprite.Height;
            mario.State = new LeftCrouchingMarioState(mario);
            mario.UpdateArt();
            mario.GameObjectPhysics.IncrementMove(Side.Down,Math.Abs(mario.Sprite.Height - previous_h));
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.GameObjectPhysics.Jump();
            mario.PowerUpState.Jump(mario);
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

        public override void Fire()
        {
            mario.Launcher.Fire(ShootAngle.Left);
        }

        public override void ClimbUp()
        {
            mario.State = new LeftClimbingMarioState(mario);
            mario.GameObjectPhysics.Climb(Side.Up);
            mario.UpdateArt();
        }

    }
}
