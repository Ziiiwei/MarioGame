using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Interfaces
{
    interface IEnemyState
    {
        void TakeDamage();
        void ChangeDirection();
    }
}
