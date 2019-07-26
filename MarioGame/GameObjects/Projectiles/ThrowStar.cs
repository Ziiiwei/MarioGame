using Gamespace.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Projectiles
{
    class ThrowStar : Fireball, IProjectile
    {

        public ThrowStar(Vector2 positionOnScreen, ShootAngle angle) : base(positionOnScreen, angle)
        {
        }

        public ThrowStar() : this(new Vector2(0), ShootAngle.Right)
        {
            trajectoryLog = new Dictionary<ShootAngle, Func<Vector2, Func<Vector2, int, Vector2>>>
            {
                {ShootAngle.Left, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X - GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(
                        (float)(p.X+v_x*t+Numbers.BLOCK_SPACING_SCALE*(Math.Sin(Math.PI+Math.PI/10*t))),
                        (float)(p.Y+v_y*t-2*Numbers.BLOCK_SPACING_SCALE*(Math.Sin(-Math.PI/2+Math.PI/15*t)+1))
                        ));
                }) },

                 {ShootAngle.Right, new Func<Vector2, Func<Vector2, int, Vector2>>((ini_v) =>
                {
                    float v_x = ini_v.X + GameObjectPhysics.PhysicsConstants.X_V;
                    float v_y = ini_v.Y;
                    return new Func<Vector2, int, Vector2>((p,t)=>new Vector2(
                        (float)(p.X+v_x*t+Numbers.BLOCK_SPACING_SCALE*(Math.Sin(Math.PI/10*t))),
                        (float)(p.Y+v_y*t-2*Numbers.BLOCK_SPACING_SCALE*(Math.Sin(-Math.PI/2+Math.PI/15*t)+1))
                        ));
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