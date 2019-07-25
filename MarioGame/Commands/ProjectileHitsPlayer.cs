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

        public ProjectileHitsPlayer(IProjectile projectile, CollisionData collisionData)
        {
            this.projectile = projectile;
        }

        public void Execute()
        {
            
        }
    }
}
