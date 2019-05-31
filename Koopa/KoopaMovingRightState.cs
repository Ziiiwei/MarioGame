using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;

namespace Sprint2
{
    class KoopaMovingRightState : IKoopaState
    {
        private Koopa koopa;

        public KoopaMovingRightState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaRightStompedState(koopa));
            koopa.UpdateArt();
        }

        public void ChangeDirection()
        {
            koopa.SetState(new KoopaMovingLeftState(koopa));
            koopa.UpdateArt();
        }

        public void IsDead()
        {
            //do nothing
        }

        public void IsFlipped()
        {
            koopa.SetState(new KoopaFlipedState(koopa));
        }
    }
}
