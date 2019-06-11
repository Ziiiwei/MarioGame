using Gamespace;
using Gamespace.Commands;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class PushMarioDown : ICommand
    {
        IMario mario;
        CollisionData collisionData;

        public PushMarioDown(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            mario.CollideDown(collisionData.CollisionArea);
        }
    }
}
