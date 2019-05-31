using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class CoinBlockStateSome : IBlockState
    {
        private CoinBlock coinBlock;

        public CoinBlockStateSome(CoinBlock coinBlock)
        {
            this.coinBlock = coinBlock;
        }

        public void MarioHitBlock()
        {
            coinBlock.SetState(new CoinBlockStateFew(coinBlock));
        }

        public void Update()
        {
            coinBlock.Sprite.Update(1);
        }
    }
}
