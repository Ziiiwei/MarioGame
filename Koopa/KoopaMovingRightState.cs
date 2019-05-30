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
            this.koopa.Sprite = SpriteFactory.Instance.CreateKoopaRight();
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaRightStompedState(koopa));
        }

        public void ChangeDirection()
        {
            koopa.SetState(new KoopaMovingLeftState(koopa));
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
