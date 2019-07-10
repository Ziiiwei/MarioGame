using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class LeftMovingGoombaState : IEnemyState
    {
        private Goomba goomba;

        public LeftMovingGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void ChangeDirection()
        {
            goomba.State = new RightMovingGoombaState(goomba);
            goomba.GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }

        public void SlideLeft()
        {
            // do nothing
        }

        public void SlideRight()
        {
            // do nothing
        }

        public void TakeDamage()
        {
            goomba.State = new StompedGoombaState(goomba);
        }
    }
}
