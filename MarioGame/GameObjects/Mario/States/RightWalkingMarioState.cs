using Gamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Gamespace.States
{
    class RightWalkingMarioState : MovingMarioState
    {
        public RightWalkingMarioState(IMario mario) : base(mario)
        {
            this.mario = mario;
        }
        public override void Jump()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.GameObjectPhysics.MoveMaxSpeed(Side.Up);
        }
        public override void MoveLeft()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.GameObjectPhysics.Stop(Side.Left);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.GameObjectPhysics.Move(Side.Right);
        }

        public override void FrictionStop()
        {
            mario.GameObjectPhysics.FrictionStop(Side.Right);
            if (mario.GameObjectPhysics.Velocity.X == 0)
            {
                mario.State = new RightStandingMarioState(mario);
                mario.UpdateArt();
            }
        }

        public override void Fire()
        {
            Vector2 fireballPosition = new Vector2(mario.PositionOnScreen.X + mario.Sprite.Width,
                mario.PositionOnScreen.Y);
            IProjectile fireball = new Fireball(fireballPosition, Side.Right);
            World.Instance.AddGameObject(fireball);
            fireball.MoveRight();
        }
    }
}
