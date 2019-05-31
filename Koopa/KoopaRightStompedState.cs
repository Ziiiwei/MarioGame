using Sprint2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class KoopaRightStompedState : IKoopaState
    {
        private Koopa koopa;

        public KoopaRightStompedState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void BeStomped()
        {
            // do nothing
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
            koopa.UpdateArt();
        }
    }
}
