using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class HitBlock : ICommand
    {
        IBlocks block;
        public HitBlock(IBlocks block)
        {
            this.block = block;
        }
        public void Execute()
        {
            block.MarioHitBlock();
        }
    }
}
