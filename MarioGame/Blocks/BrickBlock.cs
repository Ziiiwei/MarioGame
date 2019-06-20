
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
    internal class BrickBlock : AbstractGameObject, IBumpable, IDestroyable
    {
        private static int[] bumpOffsets = { 0, 1, 2, 3, -1, -2, -3 };
        private int bumpCounter = -1;
        private bool isBumped = false;

        public BrickBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
        }

        public void Bump()
        {
            if (!isBumped)
            {
                isBumped = true;
                bumpCounter = 0;
            }
        }

        public void Destroy()
        {
            World.Instance.RemoveFromWorld(this.Uid);
        }

        public override void Update()
        {
            base.Update();
            if (isBumped)
            {
                positionOnScreen.Y -= bumpOffsets[bumpCounter];
                bumpCounter = (bumpCounter + 1) % bumpOffsets.Length;
            }
            
            if (bumpCounter == 0)
            {
                isBumped = false;
            }

        }
    }
}
