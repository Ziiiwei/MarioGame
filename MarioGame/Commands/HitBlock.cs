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

        //private IGameObject obj;
        //private Rectangle r;

        public HitBlock(Block block, Rectangle r)
        {
            this.block = block;
           // this.obj = obj;
            // this.r = r;
        }

        public void Execute()
        {
            block.MarioHitBlock();
        }
    }
}
