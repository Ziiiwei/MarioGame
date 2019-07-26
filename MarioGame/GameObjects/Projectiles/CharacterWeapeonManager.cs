using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Blocks;
using Gamespace.Projectiles;

namespace Gamespace.Projectiles
{
    public enum ShootAngle : int { None, Up, Down, Left, Right, LeftUp, RightUp,LeftDown,RightDown};
    class CharacterWeapeonManager
    {
  
        private Dictionary<Type, (Func<IProjectile> ammoType, int ammoMax, int fillSpeed)> weapeonLog;
        private Dictionary<Type, List<(Func<IProjectile>,int)>> massweapeonLog;
        static CharacterWeapeonManager() { }
        private CharacterWeapeonManager()
        {
            weapeonLog = new Dictionary<Type, (Func<IProjectile> ammoType, int ammoMax, int fillSpeed)>
            {
                {typeof(Mario),(new Func<IProjectile>(()=>new Fireball()),10,5)},
                {typeof(Scout),(new Func<IProjectile>(()=>new Bullet1()),20,20)},
                {typeof(Tank),(new Func<IProjectile>(()=>new Bomb()),5,60)},
                {typeof(Thief),(new Func<IProjectile>(()=>new ThrowStar()),10,20)},
                {typeof(Soldier),(new Func<IProjectile>(()=>new Bullet2()),20,20)}
            };

            massweapeonLog = new Dictionary<Type, List<(Func<IProjectile>,int)>>
            {
                {
                    typeof(BrickBlock),
                    new List<(Func<IProjectile>,int)> {
                        (new Func<IProjectile>(() => new BrickBlockPart1()),1),
                        (new Func<IProjectile>(() => new BrickBlockPart2()),1),
                        (new Func<IProjectile>(() => new BrickBlockPart3()),1),
                        (new Func<IProjectile>(() => new BrickBlockPart4()),1)
                     }
                },
                {
                    typeof(Bomb),
                    new List<(Func<IProjectile>,int)>
                    {
                        (new Func<IProjectile>(() => new Explosion()),5),                  
                    }
                }
            };

        }
        public static CharacterWeapeonManager Instance { get; } = new CharacterWeapeonManager();

        public ProjectileLauncher GetWeapeon(IGameObject gameObject)
        {

            Type type = gameObject.GetType();
            ProjectileLauncher launcher = new ProjectileLauncher(gameObject, weapeonLog[type].ammoType,
                weapeonLog[type].fillSpeed)
            {
                MaxProjectiles = weapeonLog[type].ammoMax
            };

            return launcher;

        }

        public MassProjectileLauncher GetMassWeapeon(IGameObject gameObject)
        {
            Type type = gameObject.GetType();
            MassProjectileLauncher launcher = new MassProjectileLauncher(gameObject, massweapeonLog[type], 0)
            {
                MaxProjectiles = 0
            };
            return launcher;
        }
    }
}
