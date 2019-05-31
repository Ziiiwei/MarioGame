using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2.Interfaces;

namespace Sprint2.GoombaState
{
    class RightMovingStompedGoombaState : IGoombaState
    {
        private Goomba goomba;

        public RightMovingStompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            this.goomba.Sprite = SpriteFactory.Instance.GetSprite("Goomba");
        }

        public void BeStomped()
        {
            // do nothing
        }

        public void ChangeDirection()
        {
            goomba.SetState(new LeftMovingGoombaState(goomba));
        }

        public void IsDead()
        {
            //do nothing
        }
    }
}
