using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    interface IBlock : IGameObject
    {
        void Draw();
        void Update();
        void MarioHitBlock();
        bool IsDestroyable();

    }
}
