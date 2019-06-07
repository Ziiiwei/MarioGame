using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class BrickBlock : IBlock
    {
        public AbstractGameStatefulObject<IBlock> block { get; set; }

        public BrickBlock()
        {
            
        }

        public void MarioHitBlock()
        {
            block.SetState(new HiddenBlock());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
