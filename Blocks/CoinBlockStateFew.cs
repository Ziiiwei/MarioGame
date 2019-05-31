using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class CoinBlockStateFew : IBlockState
    {
        private CoinBlock coinBlock;

        public CoinBlockStateFew(CoinBlock coinBlock)
        {
            this.coinBlock = coinBlock;
        }

        public void MarioHitBlock()
        {
            coinBlock.SetState(new CoinBlockStateNone(coinBlock));
        }

        public void Update()
        {
            coinBlock.Sprite.Update(2);
        }
    }
}
