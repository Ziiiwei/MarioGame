using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaFlippedState : IKoopaState
    {
        private Koopa koopa;

        public KoopaFlippedState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaFlippedState(koopa));
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
