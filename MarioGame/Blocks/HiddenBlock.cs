using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class HiddenBlock : IBlock
    {
        public AbstractGameStatefulObject<IBlock> block { get; set; }

        public HiddenBlock()
        {   
        }

        public void MarioHitBlock()
        {
            block.SetState(new UsedBlock());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
