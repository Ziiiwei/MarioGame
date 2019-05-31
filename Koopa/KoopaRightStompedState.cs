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
            this.koopa.Sprite = SpriteFactory.Instance.GetSprite("KoopaStomped");
        }

        public void BeStomped()
        {
            // do nothing
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
