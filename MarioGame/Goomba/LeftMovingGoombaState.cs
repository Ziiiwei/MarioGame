using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class LeftMovingGoombaState : IGoombaState
    {
        private Goomba goomba;

        public LeftMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }
        public void BeStomped()
        {
            goomba.State = new StompedGoombaState(goomba);
            goomba.UpdateArt();
        }

        public void ChangeDirection()
        {
            goomba.State = new RightMovingGoombaState(goomba);
        }

        public void IsDead()
        {
           // do nothing yet
        }
    }
}
