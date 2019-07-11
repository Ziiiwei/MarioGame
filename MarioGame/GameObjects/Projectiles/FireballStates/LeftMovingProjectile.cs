using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class LeftMovingProjectile : IProjectileState
    {
        private IProjectile projectile;

        public LeftMovingProjectile(IProjectile projectile)
        {
            this.projectile = projectile;
        }

        public void ChangeDirection()
        {
            projectile.State = new RightMovingProjectile(projectile);
            projectile.Move(Side.Right);
        }
    }
}
