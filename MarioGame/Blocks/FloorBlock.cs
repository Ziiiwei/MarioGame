using Gamespace.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class FloorBlock : AbstractGameObject, IBlock
    {
        public FloorBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }

    }
}

