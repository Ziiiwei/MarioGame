using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class DestroyBlock : ICommand
    {
        private IDestroyable block;

        public DestroyBlock(IDestroyable block, CollisionData collisionData)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.Destroy();
        }
    }
}
