using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Block
{
    interface IBlock : IGameObject
    {
        void Draw();
        void MarioHitBlock();
        bool IsDestroyable();

    }
}
