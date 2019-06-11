using Gamespace;
using Gamespace.Blocks;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    internal class BrickBlock : AbstractGameObject
    {
        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
        }

        public void MarioHitBlock()
        {
        }
    }
}
