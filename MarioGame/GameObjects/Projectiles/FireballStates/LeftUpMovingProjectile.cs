using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class LeftUpMovingProjectile : MovingProjectileState
    {
        public LeftUpMovingProjectile(IProjectile projectile) : base(projectile)
        {
            this.projectile.Angle = ShootAngle.LeftUp;
        }

        public override void ChangeDirection(ShootAngle angle)
        {
            base.ChangeDirection(angle);
            projectile.Shoot(angle);
        }
    }
}
