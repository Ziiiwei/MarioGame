using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class QuestionBlockState : IBlockState
    {
        public AbstractGameStatefulObject<IBlockState> block { get; set; }

        public QuestionBlockState() { }
        

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
