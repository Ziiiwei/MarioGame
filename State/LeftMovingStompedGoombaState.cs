﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;

namespace Sprint2.GoombaState
{
    class LeftMovingStompedGoombaState : IGoombaState
    {
        private Goomba goomba;

        public LeftMovingStompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void BeStomped()
        {
            //do nothing already stomped
        }

        public void ChangeDirection()
        {
            goomba.SetState(new RightMovingGoombaState(goomba));
            goomba.UpdateArt();
        }

        public void IsDead()
        {
            //do nothing
        }
    }
}
