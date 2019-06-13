using Gamespace.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Commands
{
    class BumpBlock : ICommand
    {
        private IBumpableBlock block;
        public BumpBlock(IBumpableBlock block, CollisionData collisionData)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.Bump();
        }
    }
}
