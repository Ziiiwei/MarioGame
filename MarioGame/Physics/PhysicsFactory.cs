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
        private static readonly PhysicsFactory instance = new PhysicsFactory();

        static PhysicsFactory()
        {
        }

        private PhysicsFactory()
        {
        }

        internal static PhysicsFactory Instance
        {
            get
            {
                return instance;
            }
        }

        internal IPhysics GetPhysics(IGameObject gameObject, Vector2 positionOnScreen)
        {
            return new Physics(gameObject, positionOnScreen, PhysicsConstants.Instance.GetConstants(gameObject.GetType()));
        }

    }
}
