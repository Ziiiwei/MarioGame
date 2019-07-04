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

        public CollisionData(Rectangle collisionArea)
        {
            CollisionArea = collisionArea;
        }
    }
}
