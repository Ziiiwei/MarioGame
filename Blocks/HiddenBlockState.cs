using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class HiddenBlockState : IBlockState
    {
        public AbstractGameStatefulObject<IBlockState> block { get; set; }

        public HiddenBlockState()
        {   
        }

        public void MarioHitBlock()
        {
            block.SetState(new UsedBlockState());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
