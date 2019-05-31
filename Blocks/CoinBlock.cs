using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    class CoinBlock : AbstractGameObject
    {
        private IBlockState State;

        public CoinBlock(Vector2 positionOnScreen) : base(positionOnScreen)
        {
            this.State = new CoinBlockStateMany(this);
        }

        public void MarioHitBlock()
        {
            State.MarioHitBlock();
        }
        public void SetState(IBlockState newState)
        {
            State = newState;
        }
    }
}


