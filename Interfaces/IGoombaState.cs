using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    public interface IGoombaState
    {
        void ChangeDirection();
        void BeStomped();
        void IsDead();
    }
}
