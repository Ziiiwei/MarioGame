using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class ProjectileRemoveCommand : ICommand
    {
        private IProjectile projectile;

        public ProjectileRemoveCommand(IProjectile projectile, CollisionData collisionData)
        {
            this.projectile = projectile;
        }

        public void Execute()
        {
            projectile.Remove();
        }
    }
}
