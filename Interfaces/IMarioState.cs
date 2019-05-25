using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    interface IMarioState
    {
        void FireMario();
        void BigMario();
        void SmallMario();
        void TakeDamage();
        void Update();
    }
}
