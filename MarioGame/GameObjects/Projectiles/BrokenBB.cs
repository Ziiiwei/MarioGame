using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class BrokenBB : Fireball, IProjectile
    {
        public BrokenBB(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen,angle)
        {

        }
    }
}
