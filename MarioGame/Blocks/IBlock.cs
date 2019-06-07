using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Gamespace.Blocks
{
    public interface IBlock
    {
        AbstractGameStatefulObject<IBlock> block { get; set; }

        void MarioHitBlock();

        void Update();

    }
}
