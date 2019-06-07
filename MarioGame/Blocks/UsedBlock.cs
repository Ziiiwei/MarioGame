using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Blocks
{
    class UsedBlock : IBlock
    {
        public AbstractGameStatefulObject<IBlock> block { get; set; }

        public UsedBlock()
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
