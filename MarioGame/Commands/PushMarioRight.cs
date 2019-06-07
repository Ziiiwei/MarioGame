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
        Rectangle collisionArea;
        public PushMarioRight(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }
        public void Execute()
        {
            mario.CollideRight(collisionArea);
        }
    }
}
