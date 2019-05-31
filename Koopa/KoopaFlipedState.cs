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
            this.koopa.Sprite = SpriteFactory.Instance.GetSprite("KoopaFlipped");
        }

        public void BeStomped()
        {
            koopa.SetState(new KoopaLeftStompedState(koopa));
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
