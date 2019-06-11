using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class StompedGoombaState : IGoombaState
    {
        private Goomba goomba;

        public StompedGoombaState(Goomba goomba)
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
            // do nothing
        }

        public void IsDead()
        {
            //do nothing
        }
    }
}
