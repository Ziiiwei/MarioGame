using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Blocks;

namespace Gamespace.Projectiles
{
    public enum ShootAngle : int { None, Up, Down, Left, Right, LeftUp, RightUp};
    class CharacterWeapeonManager
    {
  
        private Dictionary<Type, (Func<IProjectile> ammoType, int ammoMax, int fillSpeed)> weapeonLog;
        static CharacterWeapeonManager() { }
        private CharacterWeapeonManager()
        {
            weapeonLog = new Dictionary<Type, (Func<IProjectile> ammoType, int ammoMax, int fillSpeed)>
            {
                {typeof(Mario),(new Func<IProjectile>(()=>new Fireball()),10,5)},
                {typeof(BrickBlock),(new Func<IProjectile>(()=>new Fireball()),10,5)},
                {typeof(Scout),(new Func<IProjectile>(()=>new Bullet1()),20,5)},
                {typeof(Tank),(new Func<IProjectile>(()=>new Fireball()),20,5)},
                {typeof(Thief),(new Func<IProjectile>(()=>new ThrowStar()),10,10)},
                {typeof(Soldier),(new Func<IProjectile>(()=>new Bullet2()),20,5)}
            };

        }
        public static CharacterWeapeonManager Instance { get; } = new CharacterWeapeonManager();

        public ProjectileLauncher GetWeapeon(IGameObject gameObject)
        {

            Type type = gameObject.GetType();
            ProjectileLauncher launcher = new ProjectileLauncher(gameObject,weapeonLog[type].ammoType,
                weapeonLog[type].fillSpeed);
            launcher.MaxProjectiles = weapeonLog[type].ammoMax;

            return launcher;

        }
    }
}
