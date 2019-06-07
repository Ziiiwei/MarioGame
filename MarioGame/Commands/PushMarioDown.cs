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
        Rectangle collisionArea;
        public PushMarioDown(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }
        public void Execute()
        {
            mario.CollideDown(collisionArea);
        }
    }
}
