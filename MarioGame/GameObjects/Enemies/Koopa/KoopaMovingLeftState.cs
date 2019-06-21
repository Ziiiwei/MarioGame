using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaMovingLeftState : IEnemyState
    {
        private Koopa koopa;

        public KoopaMovingLeftState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            koopa.State = new KoopaMovingRightState(koopa);
            koopa.UpdateArt();
        }

        public void TakeDamage()
        {
            koopa.State = new KoopaFlippedState(koopa);
            koopa.UpdateArt();
        }
    }
}
