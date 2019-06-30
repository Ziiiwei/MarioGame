using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class RightMovingProjectile : IProjectileState
    {
        private IProjectile projectile;

        public RightMovingProjectile(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public void ChangeDirection()
        {
            projectile.State = new LeftMovingProjectile(projectile);
            projectile.MoveLeft();
        }
    }
}
