using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class RightMovingGoombaState : IEnemyState
    {
        private Goomba goomba;

        public RightMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            goomba.State = new LeftMovingGoombaState(goomba);
        }

        public void TakeDamage()
        {
            goomba.State = new StompedGoombaState(goomba);
        }
    }
}
