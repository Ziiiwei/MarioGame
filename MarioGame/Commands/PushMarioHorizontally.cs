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
    class PushMarioHorizontally : ICommand
    {
        IMario mario;
        Rectangle collisionArea;
        public PushMarioHorizontally(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }
        public void Execute()
        {
            mario.CollideHorizontally(collisionArea);
        }
    }
}
