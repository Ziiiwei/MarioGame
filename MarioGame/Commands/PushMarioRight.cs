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
    class PushMarioRight : ICommand
    {
        IMario mario;
        CollisionData collisionData;

        public PushMarioRight(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            mario.CollideRight(collisionData.CollisionArea);
        }
    }
}
