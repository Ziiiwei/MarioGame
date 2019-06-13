using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class HiddenBlock : Block
    {
        public HiddenBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {

        }

        public override void MarioHitBlock()
        {
            World.Instance.RemoveFromWorld(this.Uid);
        }

    }
}
