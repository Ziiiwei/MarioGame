using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class Bullet1 : AbstractGameStatefulObject<IProjectileState>, IProjectile
    {
        public Bullet1(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen)
        {

        }
        public ShootAngle Angle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ChangeDirection(ShootAngle angle)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Shoot(ShootAngle angle)
        {
            throw new NotImplementedException();
        }

        public void Shoot(ShootAngle angle, Vector2 initialV, Vector2 initialP)
        {
            throw new NotImplementedException();
        }
    }
}
