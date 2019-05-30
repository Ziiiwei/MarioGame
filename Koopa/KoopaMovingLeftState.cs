using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;

namespace Sprint2
{
    class KoopaMovingLeftState : IKoopaState
    {
        private Koopa koopa;

        public KoopaMovingLeftState(Koopa koopa)
        {
            this.koopa = koopa;
            this.koopa.Sprite = SpriteFactory.Instance.CreateKoopaLeft();
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaLeftStompedState(koopa));
        }

        public void ChangeDirection()
        {
            koopa.SetState(new KoopaMovingRightState(koopa));
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
