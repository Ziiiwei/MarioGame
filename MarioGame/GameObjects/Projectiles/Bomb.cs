using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class Bomb : Fireball, IProjectile
    {
        public Bomb(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen, angle)
        {

        }
      

    
    }
}
