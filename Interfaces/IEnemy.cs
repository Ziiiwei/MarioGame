using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    interface IEnemy
    {
        void GetStomped();
        void MoveLeft();
        void MoveRight();
        void Draw();
        void Update();
    }
}
