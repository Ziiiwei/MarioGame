using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class RightSlidingMarioState : MovingMarioState
    {


        public RightSlidingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
            mario.GameObjectPhysics.Move(Side.Right);
        }

        public override void Jump()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.PowerUpState.Jump(mario);
            mario.UpdateArt();
        }

        public override void MoveLeft()
        {
            mario.State = new RightWalkingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Left);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {

            mario.State = new LeftStandingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Right);
            mario.UpdateArt();

        }

        public override void Fire()
        {
            mario.Launcher.Fire(Projectiles.ShootAngle.Right);
        }
    }
}
