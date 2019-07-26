using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Items;
using Gamespace.Koopas;
using Gamespace.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class PhysicsFactory
    {
        private Dictionary<Type, Type> physicsAssignment;
        static PhysicsFactory()
        {
        }

        private PhysicsFactory()
        {
            physicsAssignment = new Dictionary<Type, Type>()
            {
                {typeof(Mario), typeof(MarioPhysics) },
                {typeof(RedShroom), typeof(ShroomPhysics) },
                {typeof(GreenShroom), typeof(ShroomPhysics) },
                {typeof(BrickBlock), typeof(BumpableBlockPhysics) },
                {typeof(Fireball), typeof(TrajectoryPhysics) },
                {typeof(Bomb), typeof(TrajectoryPhysics) },
                {typeof(Bullet1), typeof(TrajectoryPhysics) },
                {typeof(Bullet2), typeof(TrajectoryPhysics) },
                {typeof(BrokenBB), typeof(TrajectoryPhysics) },
                {typeof(ThrowStar),typeof(TrajectoryPhysics) },
                {typeof(Goomba), typeof(EnemyPhysics) },
                {typeof(Koopa), typeof(EnemyPhysics) },
                {typeof(Tank), typeof(MarioPhysics) },
                {typeof(Thief), typeof(MarioPhysics) },
                 {typeof(Soldier), typeof(MarioPhysics) },
                  {typeof(Scout), typeof(MarioPhysics) }

            };
        }

        internal static PhysicsFactory Instance { get; } = new PhysicsFactory();

        internal IPhysics GetPhysics(IGameObject gameObject, Vector2 positionOnScreen)
        {
            Type physicsType = typeof(Physics);
            if (physicsAssignment.ContainsKey(gameObject.GetType()))
            {
                physicsType = physicsAssignment[gameObject.GetType()];
            }
            (float g, float a, float x, float y, float f) constants = PhysicsConstants.Instance.GetConstants(gameObject.GetType());
            return (IPhysics)Activator.CreateInstance(physicsType, gameObject, positionOnScreen, constants);
        }

        internal IPhysics GetNewConstants(IPhysics physics, IGameObject gameObject, Type constantsKey)
        {
            Vector2 positionOnScreen = gameObject.PositionOnScreen;
            (float G, float A, float X_V, float Y_V, float F) constants = PhysicsConstants.Instance.GetConstants(constantsKey);
            return (IPhysics) Activator.CreateInstance(physics.GetType(), gameObject, positionOnScreen, constants);
        }

        internal IPhysics GetNullPhysics(Vector2 positionOnScreen)
        {
            IGameObject nullGameObject = new NullGameObject();
            return new Physics(nullGameObject, positionOnScreen, PhysicsConstants.Instance.GetConstants(nullGameObject.GetType()));
        }

  
    }
}
