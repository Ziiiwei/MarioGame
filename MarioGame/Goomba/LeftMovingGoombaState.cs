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
            goomba.SetState(new LeftMovingStompedGoombaState(goomba));
        }

        public void ChangeDirection()
        {
            goomba.SetState(new RightMovingGoombaState(goomba));
        }

        public void IsDead()
        {
           // do nothing yet
        }
    }
}
