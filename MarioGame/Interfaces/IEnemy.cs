using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.Interfaces
{
    interface IEnemy
    {
        IEnemyState State { get; }
        void ChangeDirection();
        void TakeDamage();
    }
}
