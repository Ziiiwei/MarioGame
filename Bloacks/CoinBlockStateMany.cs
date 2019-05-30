using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class CoinBlockStateMany : IBlockState
    {
        private CoinBlock coinBlock;

        public CoinBlockStateMany(CoinBlock coinBlock)
        {
            this.coinBlock = coinBlock;
        }

        public void MarioHitBlock()
        {
            coinBlock.SetState(new CoinBlockStateSome(coinBlock));
        }

        public void Update()
        {
            coinBlock.Sprite.Update(0);
        }
    }
}
