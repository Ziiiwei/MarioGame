using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal class CollisionData
    {
        public Rectangle CollisionArea { get;  }
        public IGameObject CollisionTarget { get; }

        public CollisionData(Rectangle collisionArea, IGameObject collisionObject)
        {
            CollisionArea = collisionArea;
            CollisionTarget = collisionObject;
        }
    }
}
