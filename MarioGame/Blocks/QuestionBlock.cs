using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class QuestionBlock : IBlock
    {
        public AbstractGameStatefulObject<IBlock> block { get; set; }

        public QuestionBlock() { }
        

        public void MarioHitBlock()
        {
            block.SetState(new UsedBlock());
        }

        public void Update()
        {
            // do nothing
        }

    }
}
