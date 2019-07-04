using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaMovingRightState : IEnemyState
    {
        private Koopa koopa;

        public KoopaMovingRightState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
            koopa.State = new KoopaMovingLeftState(koopa);
            koopa.UpdateArt();
        }

        public void TakeDamage()
        {
            koopa.State = new KoopaFlippedState(koopa);
            koopa.UpdateArt();
        }
    }
}
