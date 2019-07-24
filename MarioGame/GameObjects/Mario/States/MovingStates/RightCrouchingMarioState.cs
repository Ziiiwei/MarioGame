using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class RightCrouchingMarioState : MovingMarioState
    {


        public RightCrouchingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }
        public override void Jump()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveLeft()
        {
            mario.State = new LeftCrouchingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Fire()
        {
            mario.Launcher.Fire(Projectiles.ShootAngle.Right);
        }

        public override void Stand()
        {
            int previous_h = mario.Sprite.Height;
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
            mario.GameObjectPhysics.IncrementMove(Side.Up, Math.Abs(previous_h - mario.Sprite.Height));
          
        }

    }
}
