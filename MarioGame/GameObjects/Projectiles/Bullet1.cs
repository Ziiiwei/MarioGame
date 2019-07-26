using Gamespace.Data;
using Gamespace.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class Bullet1 : Fireball, IProjectile
    {

        public Bullet1(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen, angle)
        { 
        }

        public Bullet1() : this(new Vector2(0), ShootAngle.Right)
        {
            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
                {ShootAngle.Left, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X - GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y - GameObjectPhysics.PhysicsConstants.Y_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

                 {ShootAngle.Right, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y - GameObjectPhysics.PhysicsConstants.Y_V;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },

                 {ShootAngle.Up, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X;
                    float v_y = ini_v.Y -GameObjectPhysics.PhysicsConstants.Y_V;;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) },
                   {ShootAngle.Down, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X;
                    float v_y = ini_v.Y +GameObjectPhysics.PhysicsConstants.Y_V;;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(p.X+v_x*t,p.Y+v_y*t+0.5f*GameObjectPhysics.PhysicsConstants.G*t*t));
                }) }
            };
        }      
    }
}
