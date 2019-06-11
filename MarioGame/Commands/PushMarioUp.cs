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
    class PushMarioUp : ICommand
    {
        IMario mario;
        CollisionData collisionData;

        public PushMarioUp(IMario mario, CollisionData collisionData)
        {
            this.mario = mario;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            mario.CollideUp(collisionData.CollisionArea);
        }
    }
}
