using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Blocks;
using Microsoft.Xna.Framework;

namespace Gamespace.Commands
{
    class HitBlock : ICommand
    {
        private Block block;

 

        public HitBlock(Block block, Rectangle r)
        {
            this.block = block;
        
        }

        public void Execute()
        {
            block.MarioHitBlock();
        }
    }
}
