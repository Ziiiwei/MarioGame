using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamespace.States
{
    public interface IMarioState
    {
        void Jump();
        void Crouch();
        void MoveRight();
        void MoveLeft();
        void Land();
        void FrictionStop();
        void Fire();
        void ClimbUp();
        void ClimbDown();
        void Stand();
        bool Jumpable();
    }
}
