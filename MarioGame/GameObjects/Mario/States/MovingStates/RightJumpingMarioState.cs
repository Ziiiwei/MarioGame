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

        public override void MoveLeft()
        {
            mario.State = new LeftJumpingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Left);
            mario.UpdateArt();
        }

        public override void MoveRight()
        {
            mario.GameObjectPhysics.Move(Side.Right);
        }

        public override void Land()
        {
            mario.State = new RightStandingMarioState(mario);
            mario.UpdateArt();
        }

        public override void Fire()
        {
            mario.Projectiles.Fire(Side.Right);
        }
    }
}
