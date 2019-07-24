using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class UpMovingProjectile : MovingProjectileState
    {
        public UpMovingProjectile(IProjectile projectile) : base(projectile)
        {
            this.projectile.Angle = ShootAngle.Up;
        }

        public override void ChangeDirection(ShootAngle angle)
        {
            base.ChangeDirection(angle);
        }
    }
}
