using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    internal class PlayerHitsProjectile : ICommand
    {
        private IMario mario;
        private CollisionData collisionData;

        public PlayerHitsProjectile(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            IProjectile projectile = (IProjectile)collisionData.CollisionTarget;

            if (projectile.OwnedBy == mario)
            {
                ICommand removeProjectile = new ProjectileRemoveCommand((IProjectile)projectile, collisionData);
                removeProjectile.Execute();
            }
            else
            {
                mario.Die();
            }
        }
    }
}
