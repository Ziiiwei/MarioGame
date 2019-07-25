using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Data;
using Gamespace.Blocks;

namespace Gamespace.Projectiles
{
    internal class ProjectileLauncher : ILauncher
    {
        private AbstractGameObject OwnedBy { get; }

        public int MaxProjectiles { get; set; }
      
        private int delayCounter;
        private int refillCounter;
        private int refillSpeed;

        private Stack<IProjectile> ammos;
        private Func<IProjectile> refill;

        private readonly Dictionary<ShootAngle, Func<Vector2>> spawnOffset;

        public ProjectileLauncher(IGameObject gameObject, Func<IProjectile> fill,int fillSpeed)
        {
            this.OwnedBy = (AbstractGameObject)gameObject;
            MaxProjectiles = Numbers.MAX_PROJECTILES;

            ammos = new Stack<IProjectile>();

            for (int i=0;i<= MaxProjectiles;i++)
            {
                ammos.Push(fill.Invoke());
            }
            refill = fill;
            refillSpeed = fillSpeed;

            spawnOffset = new Dictionary<ShootAngle, Func<Vector2>>
            {
                {ShootAngle.Left,  new Func<Vector2>(()=>new Vector2(
                    this.OwnedBy.GameObjectPhysics.Position.X,
                    this.OwnedBy.Center.Y))},
                {ShootAngle.Right,  new Func<Vector2>(()=>new Vector2(
                    this.OwnedBy.GameObjectPhysics.Position.X+this.OwnedBy.Sprite.Width,
                    this.OwnedBy.Center.Y))},
                {ShootAngle.Up, new Func<Vector2>(() => new Vector2(
                    this.OwnedBy.Center.X,
                    this.OwnedBy.GameObjectPhysics.Position.Y))}
            };
  
        }

        public void Fire(ShootAngle angle)
        {
            if (delayCounter % Numbers.DELAY_BOUND == 0 && ammos.Count>0)
            {
                IProjectile projectile = ammos.Pop();
                World.Instance.AddGameObject(projectile);
                projectile.Shoot(angle, OwnedBy.GameObjectPhysics.Velocity, spawnOffset[angle].Invoke());
            }
            delayCounter++;
        }

        public void Update()
        {
            if (refillCounter % refillSpeed ==0 && ammos.Count< Numbers.MAX_PROJECTILES)
            {
                ammos.Push(refill.Invoke());
            }
            refillCounter++;
        }
    }
}
