using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Interfaces;

namespace Gamespace.Koopas
{
    class KoopaFlippedState : IEnemyState
    {
        private Koopa koopa;

        public KoopaFlippedState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void ChangeDirection()
        {
        }

        public void TakeDamage()
        {

        }

        public void SlideLeft()
        {
            koopa.State = new KoopaFlippedLeftState(koopa);
            koopa.GameObjectPhysics.MoveMaxSpeed(Side.Left);
        }

        public void SlideRight()
        {
            koopa.State = new KoopaFlippedRightState(koopa);
            koopa.GameObjectPhysics.MoveMaxSpeed(Side.Right);
        }
    }
}
