using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class LeftMovingProjectile : MovingProjectileState
    {
        public LeftMovingProjectile(IProjectile projectile) : base(projectile)
        {
            this.projectile.Angle = ShootAngle.Left;
        }

        public override void ChangeDirection(ShootAngle angle)
        {
            base.ChangeDirection(angle);
        }
    }
}
