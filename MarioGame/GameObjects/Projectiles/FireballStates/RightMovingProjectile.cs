using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class RightMovingProjectile : MovingProjectileState
    {
        public RightMovingProjectile(IProjectile projectile) : base(projectile)
        {
            this.projectile.Angle = ShootAngle.Right;
        }

        public override void ChangeDirection(ShootAngle angle)
        {
            base.ChangeDirection(angle);
        }
    }
}
