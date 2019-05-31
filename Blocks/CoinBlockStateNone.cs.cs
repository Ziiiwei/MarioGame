using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class CoinBlockStateNone : IBlockState
    {
        private CoinBlock coinBlock;

        public CoinBlockStateNone(CoinBlock coinBlock)
        {
            this.coinBlock = coinBlock;
        }

        public void MarioHitBlock()
        {
            // DO nothing
        }

        public void Update()
        {
            coinBlock.Sprite.Update(3);
        }
    }
}
