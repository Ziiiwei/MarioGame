using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;

namespace Gamespace.States
{
    class RightJumpingMarioState : MovingMarioState
    {
        public RightJumpingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            ((MarioPhysics)mario.GameObjectPhysics).KeepJump();
        }
        public override void MoveLeft()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.GameObjectPhysics.Move(Side.Right);
        }

        public override void Land()
        {
            if (mario.GameObjectPhysics.Velocity.X != 0)
            {
                mario.State = new RightWalkingMarioState(mario);
                mario.UpdateArt();
            }
            else
            {
                mario.State = new RightStandingMarioState(mario);
                mario.UpdateArt();
            }
        }

    

        public override void Fire()
        {
            mario.Launcher.Fire(Projectiles.ShootAngle.Right);
        }

        public override bool Jumpable()
        {
            return false;
        }
    }
}
