using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    internal abstract class MovingMarioState : IMarioState
    {
         public virtual void Crouch() { }
         public virtual void Jump() { }
         public virtual void MoveLeft() { }
         public virtual void MoveRight() { }
    }
}
