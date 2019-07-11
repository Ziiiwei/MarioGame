using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaFlippedLeftState : IEnemyState
    {
        private Koopa koopa;

        public KoopaFlippedLeftState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            koopa.State = new KoopaFlippedRightState(koopa);
            koopa.GameObjectPhysics.MoveMaxSpeed(Side.Right);
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
            // do nothing
        }
    }
}
