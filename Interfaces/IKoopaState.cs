using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    public interface IKoopaState
    {
        void IsFlipped();
        void ChangeDirection();
        void IsDead();
        void BeStomped();
    }
}
