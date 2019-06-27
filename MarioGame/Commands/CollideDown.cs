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
    class CollideDown : ICommand
    {
        private ICollidable collidable;
        private CollisionData collisionData;

        public CollideDown(ICollidable collidable, CollisionData collisionData)
        {
            this.collidable = collidable;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            collidable.CollideDown(collisionData.CollisionArea);
        }
    }
}
