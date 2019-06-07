using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class PushMarioVertically : ICommand
    {
        private IMario mario;
        Rectangle collisionArea;
        public PushMarioVertically(IMario mario, Rectangle collisionArea)
        {
            this.mario = mario;
            this.collisionArea = collisionArea;
        }
        public void Execute()
        {
            mario.CollideVertically(collisionArea);
        }
    }
}
