using Gamespace.Blocks;
using Gamespace.Goombas;
using Gamespace.Items;
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
                {typeof(Mario), typeof(Physics) },
                {typeof(RedShroom), typeof(ShroomPhysics) },
                {typeof(GreenShroom), typeof(ShroomPhysics) },
                {typeof(BrickBlock), typeof(BumpableBlockPhysics) },
                {typeof(Fireball), typeof(FireballPhysics) }
            };
        }

        internal static PhysicsFactory Instance { get; } = new PhysicsFactory();

        internal IPhysics GetPhysics(IGameObject gameObject, Vector2 positionOnScreen)
        {
            Type concretePhysics = typeof(Physics);
            if (physicsAssignment.ContainsKey(gameObject.GetType()))
            {
                concretePhysics = physicsAssignment[gameObject.GetType()];
            }
            IPhysicsConstants constants = PhysicsConstants.Instance.GetConstants(gameObject.GetType());
            return (IPhysics)Activator.CreateInstance(concretePhysics, gameObject, positionOnScreen, constants);
        }

        internal IPhysics GetNullPhysics(Vector2 positionOnScreen)
        {
            IGameObject nullGameObject = new NullGameObject();
            return new Physics(nullGameObject, positionOnScreen, PhysicsConstants.Instance.GetConstants(nullGameObject.GetType()));
        }
    }
}
