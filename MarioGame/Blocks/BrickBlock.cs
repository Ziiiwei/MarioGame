
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
    internal class BrickBlock : Block
    {
        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
        }

        public override void Destroy()
        {
            World.Instance.RemoveFromWorld(this.Uid);
        }
    }
}
