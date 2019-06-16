using Gamespace;
using Gamespace.Commands;
using Gamespace.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class CollideLeft : ICommand
    {
        ICollidable collidable;
        CollisionData collisionData;

        public CollideLeft(ICollidable collidable, CollisionData collisionData)
        {
            this.collidable = collidable;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            collidable.CollideLeft(collisionData.CollisionArea);
        }
    }
}
