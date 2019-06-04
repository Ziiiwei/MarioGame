using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class BrickBlockState : IBlockState
    {
        public AbstractGameStatefulObject<IBlockState> block { get; set; }

        public BrickBlockState()
        {
            
        }

        public void MarioHitBlock()
        {
            block.SetState(new HiddenBlockState());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
