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

        public override void MoveLeft()
        {
            mario.GameObjectPhysics.Move(Side.Left);
        }
        public override void MoveRight()
        {
            mario.State = new RightJumpingMarioState(mario);
            mario.GameObjectPhysics.Move(Side.Right);
            mario.UpdateArt();
        }

        public override void Land()
        {
            mario.State = new LeftStandingMarioState(mario);
            mario.UpdateArt();
        }
    }
}
