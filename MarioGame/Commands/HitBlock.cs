﻿using System;
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
        private CollisionData collisionData;

        public HitBlock(Block block, CollisionData collisionData)
        {
            this.block = block;
            this.collisionData = collisionData;
        }

        public void Execute()
        {
            block.MarioHitBlock();
        }
    }
}
