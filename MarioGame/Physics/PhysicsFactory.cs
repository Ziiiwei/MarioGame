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
        static PhysicsFactory()
        {
        }

        private PhysicsFactory()
        {
        }

        internal static PhysicsFactory Instance { get; } = new PhysicsFactory();

        internal IPhysics GetPhysics(IGameObject gameObject, Vector2 positionOnScreen)
        {
            return new Physics(gameObject, positionOnScreen, PhysicsConstants.Instance.GetConstants(gameObject.GetType()));
        }

        internal IPhysics GetNullPhysics(Vector2 positionOnScreen)
        {
            IGameObject nullGameObject = new NullGameObject();
            return new Physics(nullGameObject, positionOnScreen, PhysicsConstants.Instance.GetConstants(nullGameObject.GetType()));
        }
    }
}
