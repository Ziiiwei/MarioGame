using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    interface IItem
    {
        void Draw();
        void Update();
        void MovesYDirection();
        bool ItemDestroyed();
        String ItemName();

    }
}
