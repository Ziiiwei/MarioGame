using Gamespace.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace
{
    internal interface IBumpable
    {
        IBlockBumpState State { get; set; }
        IPhysics GameObjectPhysics { get; }
        void Bump();
    }
}
