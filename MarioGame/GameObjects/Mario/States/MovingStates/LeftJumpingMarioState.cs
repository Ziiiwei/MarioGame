﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace;


namespace Gamespace.States
{
    class LeftJumpingMarioState : MovingMarioState
    {
        public LeftJumpingMarioState(IMario mario) : base(mario)
        {
        }

        public override void Jump()
        {
           ((MarioPhysics)mario.GameObjectPhysics).KeepJump();
        }

        public override void MoveLeft()
        {
            mario.GameObjectPhysics.Move(Side.Left);
        }
        public override void MoveRight()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.UpdateArt();
        }


        public override void Land()
        {
            if (mario.GameObjectPhysics.Velocity.X != 0)
            {
                mario.State = new LeftWalkingMarioState(mario);
                mario.UpdateArt();
            }
            else
            {
                mario.State = new LeftStandingMarioState(mario);
                mario.UpdateArt();
            }
        }

        public override void Fire()
        {
            mario.Projectiles.Fire(Side.Left);
        }

        public override bool Jumpable()
        {
            return false;
        }
    }
}
