using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2.Interfaces
{
    interface IMario : ISprite
    {
        void JumpLeft();
        void JumpRight();
        void MovingRight();
        void MovingLeft();
        void FacingRight();
        void FacingLeft();
        void CrouchRight();
        void CrouchLeft();
        


    }
}




