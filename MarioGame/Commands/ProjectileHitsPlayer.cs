using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    internal class ProjectileHitsPlayer : ICommand
    {
        IProjectile projectile;
        CollisionData collisionData;

        public ProjectileHitsPlayer(IProjectile projectile, CollisionData collisionData)
        {
            this.projectile = projectile;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            if (collisionData.CollisionTarget != projectile.OwnedBy)
            {
                projectile.OwnerScores();
            }
        }
    }
}
