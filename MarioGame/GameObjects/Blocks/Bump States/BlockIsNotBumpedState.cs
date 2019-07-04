using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class BlockIsNotBumpedState : IBlockBumpState
    {
        IBumpable block;

        public BlockIsNotBumpedState(IBumpable block)
        {
            this.block = block;
        }
        public void Bump()
        {
            block.State = new BlockIsBumpedState(block);

        }
    }
}
