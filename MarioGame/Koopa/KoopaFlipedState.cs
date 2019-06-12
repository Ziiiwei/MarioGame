using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaFlippedState : IEnemyState
    {
        private Koopa koopa;

        public KoopaFlippedState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            // do nothing
        }

        public void TakeDamage()
        {
            // do nothing
        }
    }
}
