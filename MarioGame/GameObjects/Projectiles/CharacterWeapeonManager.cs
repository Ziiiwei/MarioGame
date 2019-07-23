using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    public enum ShootAngle : int { None, Up, Down, Left, Right, LeftUp, RightUp};
    class CharacterWeapeonManager<IProjectiles>
    {
        public ICharacter character;
        private IProjectile projectile;
        public CharacterWeapeonManager(ICharacter character)
        {

        }
    }
}
