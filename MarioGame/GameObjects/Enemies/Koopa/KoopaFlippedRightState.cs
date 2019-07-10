using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaFlippedRightState : IEnemyState
    {
        private Koopa koopa;

        public KoopaFlippedRightState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            // do nothing
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
