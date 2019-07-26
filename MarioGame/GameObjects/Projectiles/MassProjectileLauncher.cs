using Gamespace.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class MassProjectileLauncher : ILauncher
    {
        public int MaxProjectiles { get; set; }


        private int delayCounter;
        private int refillCounter;
        private int refillSpeed;

        private Stack<IProjectile> ammos;
        private List<Func<IProjectile>> refill;

        private readonly Dictionary<ShootAngle, Func<Vector2>> spawnOffset;
        private AbstractGameObject OwnedBy { get; }
        public MassProjectileLauncher(IGameObject gameObject, List<Func<IProjectile>> fill, int fillSpeed)
        {
            this.OwnedBy = (AbstractGameObject)gameObject;
            MaxProjectiles = Numbers.MAX_PROJECTILES;

            ammos = new Stack<IProjectile>();

            foreach (Func<IProjectile>f in fill)
            {
                ammos.Push(f.Invoke());
            }
            refill = fill;
            refillSpeed = fillSpeed;

            spawnOffset = new Dictionary<ShootAngle, Func<Vector2>>
            {
                {ShootAngle.Left,  new Func<Vector2>(()=>new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X,
                    OwnedBy.Center.Y))},
                {ShootAngle.Right,  new Func<Vector2>(()=>new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X+OwnedBy.Sprite.Width,
                    OwnedBy.Center.Y))},
                {ShootAngle.Up, new Func<Vector2>(() => new Vector2(
                    OwnedBy.Center.X,
                    OwnedBy.GameObjectPhysics.Position.Y))}
            };

        }
        public void Fire(ShootAngle angle)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
