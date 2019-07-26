using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class Bullet2 : Fireball, IProjectile
    {
        public Bullet2(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen, angle)
        {
            bounceBound = 1;
        }
        public Bullet2() : this(new Vector2(0,0),ShootAngle.Right)
        {
            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
                {ShootAngle.Left, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X - GameObjectPhysics.PhysicsConstants.X_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y));
                }) },

                 {ShootAngle.Right, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y));
                }) },

                 {ShootAngle.Up, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                     float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X,p.Y));
                }) },
                   {ShootAngle.Down, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                     float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X,p.Y));
                }) }
            };
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            base.CollideLeft(collisionArea);
            ChangeDirection(ShootAngle.Right);
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            base.CollideRight(collisionArea);
            ChangeDirection(ShootAngle.Left);
        }

        protected override void SetSprite()
        {
            Sprite = SpriteFactory.Instance.GetSprite(GetType().Name, State.GetType().Name, "");
        }

        public override void Shoot(ShootAngle angle, Vector2 initialV, Vector2 initialP)
        {
            base.Shoot(angle, initialV, initialP);
            SetSprite();
        }
    }
}
