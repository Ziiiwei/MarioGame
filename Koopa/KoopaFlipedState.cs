using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;

namespace Sprint2
{
    class KoopaFlipedState : IKoopaState
    {
        private Koopa koopa;

        public KoopaFlipedState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaLeftStompedState(koopa));
            koopa.UpdateArt();
        }

        public void ChangeDirection()
        {
            //do nothing
        }

        public void IsDead()
        {
            //do nothing
        }

        public void IsFlipped()
        {
            //do nothing
        }
    }
}
