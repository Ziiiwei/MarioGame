using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Goombas
{
    class StompedGoombaState : IEnemyState
    {
        private Goomba goomba;

        public StompedGoombaState(Goomba goomba)
        {
            this.goomba = goomba;
            this.goomba.GameObjectPhysics.Stop(Side.Left);
            World.Instance.MaskCollision(goomba);
            goomba.UpdateArt();
        }

        public void ChangeDirection()
        {
            // do nothing
        }

        public void SlideLeft()
        {
            // do nothing
        }

        public void SlideRight()
        {
            // do nothing
        }

        public void TakeDamage()
        {
            // do nothing
        }
    }
}
