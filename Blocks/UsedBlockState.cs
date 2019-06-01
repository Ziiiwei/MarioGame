using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class UsedBlockState : IBlockState
    {
        public AbstractGameStatefulObject<IBlockState> block { get; set; }

        public UsedBlockState()
        {
           
        }

        public void MarioHitBlock()
        {
            //do nothing
        }

        public void Update()
        {
            //nothing yet
        }
    }
}
