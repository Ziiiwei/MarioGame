using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamespace.Items;

namespace Gamespace.Collision
{
    static class RewardChecker
    {
        public static Boolean HasCoin(IBumpable block)
        {
            // I tried comparing types but that did not work out well, any suggestions would be nice. - Rayan
            if ( !(block.bumpReward is null) && block.bumpReward.Name.Equals( "Coin" ) )
                return true;
            return false;
        }
    }
}
