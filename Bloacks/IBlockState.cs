using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IBlockState
    {
        void MarioHitBlock();

        void Update();
    }
}
