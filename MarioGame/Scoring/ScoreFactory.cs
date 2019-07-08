using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Blocks;
using Gamespace.Items;

namespace Gamespace
{
    class ScoreFactory
    {
        private IBumpable block;
        private Type bumpReward;

        public ScoreFactory(IBumpable block)
        {
            this.block = block;
            bumpReward = block.bumpReward;
        }

        public int GiveScore()
        {
            if(!(bumpReward is null) && bumpReward.Equals(typeof(Coin)))
                return ScoreConstants.COIN_SCORE;
            return 0;
        }
    }
}
