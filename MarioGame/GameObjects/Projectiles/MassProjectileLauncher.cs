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
        private List<(Func<IProjectile>,int)> refill;

        private readonly Dictionary<ShootAngle, Func<Vector2>> spawnOffset;
        private AbstractGameObject OwnedBy { get; }

        public int RemainingAmmo { get => ammos.Count; }

        public MassProjectileLauncher(IGameObject gameObject, List<(Func<IProjectile>,int)> fill, int fillSpeed)
        {
            this.OwnedBy = (AbstractGameObject)gameObject;
            MaxProjectiles = Numbers.MAX_PROJECTILES;

            ammos = new Stack<IProjectile>();

            foreach ((Func<IProjectile> ammoType,int count) in fill)
            {
                for(int i=0;i<count;i++)
                ammos.Push(ammoType.Invoke());
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
                    OwnedBy.Center.Y))}
                ,
                {ShootAngle.Up, new Func<Vector2>(() => new Vector2(
                    OwnedBy.Center.X,
                    OwnedBy.GameObjectPhysics.Position.Y))}
                ,
                {ShootAngle.LeftUp, new Func<Vector2>(() => new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X,
                    OwnedBy.GameObjectPhysics.Position.Y))}
                ,
                {ShootAngle.LeftDown, new Func<Vector2>(() => new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X,
                    OwnedBy.GameObjectPhysics.Position.Y+OwnedBy.Sprite.Height))}
                ,
                {ShootAngle.RightDown, new Func<Vector2>(() => new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X+OwnedBy.Sprite.Width,
                    OwnedBy.GameObjectPhysics.Position.Y+OwnedBy.Sprite.Height))}
                       ,
                {ShootAngle.RightUp, new Func<Vector2>(() => new Vector2(
                    OwnedBy.GameObjectPhysics.Position.X+OwnedBy.Sprite.Width,
                    OwnedBy.GameObjectPhysics.Position.Y))}
                  ,
                {ShootAngle.None, new Func<Vector2>(() => OwnedBy.Center)}
            };

        }
        public void Fire(ShootAngle angle)
        {
            IProjectile projectile;
            while (ammos.Count > 0)
            {
                projectile = ammos.Pop();
                projectile.Shoot(angle, OwnedBy.GameObjectPhysics.Velocity, spawnOffset[angle].Invoke());
                projectile.SetOwner(OwnedBy);
                World.Instance.AddGameObject(projectile);
            }
            delayCounter++;
        }

        public void Fire(List<ShootAngle> angles)
        {
            int i = 0;
            IProjectile projectile;
            while (ammos.Count > 0)
            {
                projectile = ammos.Pop();
                projectile.Shoot(angles[i], OwnedBy.GameObjectPhysics.Velocity, spawnOffset[angles[i]].Invoke());
                projectile.SetOwner(OwnedBy);
                World.Instance.AddGameObject(projectile);
                i++;
            }
            delayCounter++;
        }

        public void Update()
        {
        }
    }
}
