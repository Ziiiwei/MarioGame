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
    class CollideRight : ICommand
    {
        private ICollidable collidable;
        private CollisionData collisionData;

        public CollideRight(ICollidable collidable, CollisionData collisionData)
        {
            this.collidable = collidable;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            collidable.CollideRight(collisionData.CollisionArea);
        }
    }
}
