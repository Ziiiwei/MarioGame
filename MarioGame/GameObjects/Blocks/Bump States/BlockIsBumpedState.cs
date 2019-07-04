using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class BlockIsBumpedState : IBlockBumpState
    {
        private IBumpable block;

        public BlockIsBumpedState(IBumpable block)
        {
            this.block = block;
        }
        public void Bump()
        {
            block.GameObjectPhysics.MoveMaxSpeed(Side.Up);

        }
    }
}
