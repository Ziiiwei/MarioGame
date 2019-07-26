using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class BrickBlockPart2 : Fireball, IProjectile
    {

        public BrickBlockPart2(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen, angle)
        {
            bounceBound = 3;
        }

        public BrickBlockPart2() : this(new Vector2(0), ShootAngle.Right)
        {
            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
              
                 {ShootAngle.None, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y - GameObjectPhysics.PhysicsConstants.Y_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

            };

            bounceMove = new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
            {
                return new Func<Vector2, int, Vector2>((p, t) => new Vector2(p.X + ini_v.X * t, p.Y + ini_v.Y * t + 0.5f * GameObjectPhysics.PhysicsConstants.G * t * t));
            });
        }

        public override void CollideDown(Rectangle collisionArea)
        {
            GameObjectPhysics.DownStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X / 1.4f, -GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(bounceMove.Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideLeft(Rectangle collisionArea)
        {
            GameObjectPhysics.LeftStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X / 1.4f, GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(bounceMove.Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideRight(Rectangle collisionArea)
        {
            GameObjectPhysics.RightStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
            Vector2 ini_v = new Vector2(-GameObjectPhysics.Velocity.X / 1.4f, GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(bounceMove.Invoke(ini_v));
            bounceCounter++;
        }

        public override void CollideUp(Rectangle collisionArea)
        {
            GameObjectPhysics.UpStop(collisionArea);
            positionOnScreen = GameObjectPhysics.Position;
            Vector2 ini_v = new Vector2(GameObjectPhysics.Velocity.X / 1.4f, -GameObjectPhysics.Velocity.Y / 1.4f);
            GameObjectPhysics.TrajectMove(bounceMove.Invoke(ini_v));
            bounceCounter++;
        }
        public override void SetOwner(IGameObject owner)
        {
        }
    }
}