using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class RightMovingStompedGoombaState : IGoombaState
    {
        private Goomba goomba;

        public RightMovingStompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.UpdateArt();
        }

        public void BeStomped()
        {
            // do nothing
        }

        public void ChangeDirection()
        {
            goomba.SetState(new LeftMovingGoombaState(goomba));
        }

        public void IsDead()
        {
            //do nothing
        }
    }
}
