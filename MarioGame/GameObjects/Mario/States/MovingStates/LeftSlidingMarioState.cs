using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class LeftSlidingMarioState : MovingMarioState
    {

        public LeftSlidingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }

        public override void Jump()
        { 
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }

        // this is what depends on Mario's velocity
        public override void MoveLeft()
        {
            // if mario did not move, make him stand

            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        // mario should resume movement here
        public override void MoveRight()
        {
            mario.State = new LeftWalkingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Fire()
        {
            mario.Launcher.Fire(Projectiles.ShootAngle.Left);
        }
    }
}
